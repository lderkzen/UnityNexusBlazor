namespace UnityNexus.Stores
{
    public class RemoteUserStore : IRemoteUserStore
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

        private static UserModel? CreateUser(
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

            return new UserModel
            {
                Id = (Guid)id,
                Username = username,
                DiscordUserId = discordUserId,
                AvatarId = avatarId,
                Nickname = nickname,
                Roles = userRoles
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

        public Task<List<int>> GetAllUserIdsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserModelByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
