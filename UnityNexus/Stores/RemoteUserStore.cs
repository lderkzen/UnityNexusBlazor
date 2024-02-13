

using System.Text.Json;
using Keycloak.AuthServices.Common;

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

        public Task<List<int>> GetAllUserIdsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<NexusUser> GetUserModelByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
