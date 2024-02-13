namespace UnityNexus.Shared.Auth
{
    public interface IKeycloakAccessTokenManager
    {
        public Task SetAccessTokenAsync(HttpClient httpClient);
    }
}
