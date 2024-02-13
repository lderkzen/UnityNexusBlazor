namespace UnityNexus.Stores
{
    public class RemoteUserStore : RemoteKeycloakStore, IRemoteUserStore
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IKeycloakAccessTokenManager _keycloakAccessTokenManager;
        private readonly IRemoteRoleStore _remoteRoleStore;
        private readonly string _realm;
        private readonly string _clientId;

        public RemoteUserStore(
            IMemoryCache memoryCache,
            IHttpClientFactory httpClientFactory,
            IKeycloakAccessTokenManager keycloakAccessTokenManager,
            IRemoteRoleStore remoteRoleStore,
            KeycloakInstallationOptions keycloakInstallationOptions
        )
        {
            _memoryCache = memoryCache;
            _httpClientFactory = httpClientFactory;
            _keycloakAccessTokenManager = keycloakAccessTokenManager;
            _remoteRoleStore = remoteRoleStore;
            _realm = keycloakInstallationOptions.Realm;
            _clientId = keycloakInstallationOptions.Resource;
        }

        private static Guid? TryGetUserIdFromResponse(JsonElement userJson)
        {
            if (!userJson.TryGetProperty("id", out var id))
                return null;

            return id.GetGuid();
        }

        private static UserModel? CreateUserModel(
            string userJson,
            string rolesJson,
            Role[] allRoles
        )
        {
            JsonDocument usersDocument = JsonDocument.Parse(userJson);

            Guid? id = TryGetUserIdFromResponse(usersDocument.RootElement);
            if (id is null)
                return null;

            if (!usersDocument.RootElement.TryGetProperty("federatedIdentities", out JsonElement federatedIdentities)
                || federatedIdentities.GetArrayLength() == 0)
                return null;

            JsonElement discordIdentity = federatedIdentities[0];
            if (!discordIdentity.TryGetProperty("userName", out JsonElement userName))
                return null;

            string? username = userName.GetString();
            if (username is null)
                return null;

            if (!discordIdentity.TryGetProperty("userId", out JsonElement userId))
                return null;

            string? discordUserId = userId.GetString();
            string? avatarId = null;
            string? nickname = null;
            if (usersDocument.RootElement.TryGetProperty("attributes", out JsonElement attributes))
            {
                if (attributes.TryGetProperty("discordAvatarId", out JsonElement avatarIdArray))
                    avatarId = avatarIdArray.EnumerateArray().FirstOrDefault().GetString();

                if (attributes.TryGetProperty("discordNickname", out JsonElement nicknameArray))
                    nickname = nicknameArray.EnumerateArray().FirstOrDefault().GetString();
            }

            List<string> userRoles = ParseRoles(rolesJson);
            byte maxPowerLevel = allRoles.Where(m => userRoles.Contains(m.Name) && m.PowerLevel is not null)
                                        .Select(m => m.PowerLevel!.Value)
                                        .Append<byte>(0) // At least one value is required for Max() to work.
                                        .Max();

            return new UserModel
            {
                Id = (Guid)id,
                Username = username,
                DiscordUserId = discordUserId,
                AvatarId = avatarId,
                Nickname = nickname,
                Roles = userRoles,
                PowerLevel = maxPowerLevel
            };
        }

        private static List<string> ParseRoles(string roles)
        {
            JsonDocument rolesDocument = JsonDocument.Parse(roles);
            List<string> mappedRoles = [];

            foreach (JsonElement role in rolesDocument.RootElement.EnumerateArray())
            {
                if (!role.TryGetProperty("name", out JsonElement roleMapping))
                    continue;

                string? roleName = roleMapping.GetString();
                if (roleName is not null)
                    mappedRoles.Add(roleName);
            }

            return mappedRoles;
        }

        public async Task<List<Guid>?> GetAllUserIdsAsync()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("keycloak");
            await _keycloakAccessTokenManager.SetAccessTokenAsync(httpClient);

            HttpResponseMessage countResponse = await httpClient.GetAsync($"/admin/realms/{_realm}/users/count/?enabled=true");
            if (!countResponse.IsSuccessStatusCode)
                return null;
            string countBody = await countResponse.Content.ReadAsStringAsync();

            HttpResponseMessage response = await httpClient.GetAsync($"/admin/realms/{_realm}/users/?briefRepresentation=true&enabled=true&max={countBody}");
            if (!response.IsSuccessStatusCode)
                return null;

            string usersJson = await response.Content.ReadAsStringAsync();
            JsonDocument usersDocument = JsonDocument.Parse(usersJson);

            return usersDocument.RootElement
                .EnumerateArray()
                .Select(TryGetUserIdFromResponse)
                .Where(userId => userId is not null)
                .Cast<Guid>()
                .ToList()!;
        }

        public async Task<UserModel?> GetUserModelByIdAsync(int userId)
        {
            if (_memoryCache.TryGetValue(userId, out UserModel? result))
                return result;

            HttpClient httpClient = _httpClientFactory.CreateClient("keycloak");
            await _keycloakAccessTokenManager.SetAccessTokenAsync(httpClient);

            Guid? clientGuid = await GetClientGuid(httpClient, _keycloakAccessTokenManager, _realm, _clientId);
            if (clientGuid is null)
                return null;

            HttpResponseMessage response = await httpClient.GetAsync($"/admin/realms/{_realm}/users/{userId}");
            if (!response.IsSuccessStatusCode)
                return null;

            string userJson = await response.Content.ReadAsStringAsync();

            await _keycloakAccessTokenManager.SetAccessTokenAsync(httpClient);
            response = await httpClient.GetAsync($"/admin/realms/{_realm}/users/{userId}/role-mappings/clients/{clientGuid}/composite");
            if (!response.IsSuccessStatusCode)
                return null;

            string rolesJson = await response.Content.ReadAsStringAsync();
            Role[] allRoles = await _remoteRoleStore.GetAllRolesAsync();

            result = CreateUserModel(userJson, rolesJson, allRoles);
            if (result is null)
                return null;

            _memoryCache.Set(
                userId,
                result,
                new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(5),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                }
            );
            return result;
        }
    }
}
