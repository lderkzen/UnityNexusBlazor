namespace UnityNexus.Shared.BLL
{
    public interface IKeycloakAccessTokenManager
    {
        public Task SetAccessTokenAsync(HttpClient httpClient);
    }
}
