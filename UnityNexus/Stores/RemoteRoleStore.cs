namespace UnityNexus.Stores
{
    public class RemoteRoleStore : RemoteKeycloakStore, IRemoteRoleStore
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IKeycloakAccessTokenManager _keycloakAccessTokenManager;
        private readonly string _realm;
        private readonly string _clientId;

        public RemoteRoleStore(
            IMemoryCache memoryCache,
            IHttpClientFactory httpClientFactory,
            IKeycloakAccessTokenManager keycloakAccessTokenManager,
            KeycloakInstallationOptions keycloakInstallationOptions
        )
        {
            _memoryCache = memoryCache;
            _httpClientFactory = httpClientFactory;
            _keycloakAccessTokenManager = keycloakAccessTokenManager;
            _realm = keycloakInstallationOptions.Realm;
            _clientId = keycloakInstallationOptions.Resource;
        }

        private static Role[] ParseRolesFromJsonResponse(string rolesJson)
        {
            JsonElement rolesElement = JsonSerializer.Deserialize<JsonElement>(rolesJson);
            List<Role> rolesList = [];

            foreach (JsonElement role in rolesElement.EnumerateArray())
            {
                string? roleName = role.GetProperty("name").GetString();
                if (roleName is null)
                    continue;

                string? hexColorCode = null;
                byte? powerLevel = null;
                if (role.TryGetProperty("attributes", out JsonElement attributes))
                {
                    // Get hex color code from property "attributes" with key "hex-color-code".
                    if (attributes.TryGetProperty("hex-color-code", out JsonElement hexColorCodeProperty))
                        hexColorCode = hexColorCodeProperty.EnumerateArray().FirstOrDefault().GetString();
                    // Get power level from property "attributes" with key "power-level".
                    if (attributes.TryGetProperty("power-level", out JsonElement powerLevelProperty))
                        if (byte.TryParse(powerLevelProperty.EnumerateArray().FirstOrDefault().GetString(), out byte powerLevelValue))
                            powerLevel = powerLevelValue;
                }

                rolesList.Add(new Role(roleName, hexColorCode, powerLevel));
            }

            return rolesList.ToArray();
        }

        public async Task<Role[]> GetAllRolesAsync()
        {
            if (_memoryCache.TryGetValue("all_roles", out Role[]? result))
                return result!;

            HttpClient httpClient = _httpClientFactory.CreateClient("keycloak");
            await _keycloakAccessTokenManager.SetAccessTokenAsync(httpClient);

            Guid? clientGuid = await GetClientGuid(httpClient, _keycloakAccessTokenManager, _realm, _clientId);
            if (clientGuid is null)
                return [];

            HttpResponseMessage response = await httpClient.GetAsync($"/admin/realms/{_realm}/clients/{clientGuid}/roles?briefRepresentation=false");
            if (!response.IsSuccessStatusCode)
                return [];

            string rolesJson = await response.Content.ReadAsStringAsync();
            result = ParseRolesFromJsonResponse(rolesJson);
            _memoryCache.CreateEntry("all_roles").SetValue(result);

            return result;
        }
    }
}
