namespace UnityNexus.Server.Stores
{
    public class RemoteKeycloakStore
    {
        private static Guid? _clientGuid;

        private static Guid ParseClientGuidFromResponse(string clients)
        {
            JsonDocument clientsJson = JsonDocument.Parse(clients);
            return clientsJson.RootElement.EnumerateArray().FirstOrDefault().GetProperty("id").GetGuid();
        }

        protected static async Task<Guid?> GetClientGuid(
            HttpClient httpClient,
            IKeycloakAccessTokenManager keycloakAccessTokenManager,
            string realm,
            string clientId
        )
        {
            if (_clientGuid is not null)
                return _clientGuid;

            await keycloakAccessTokenManager.SetAccessTokenAsync(httpClient);
            HttpResponseMessage idResponse = await httpClient.GetAsync($"/admin/realms/{realm}/clients?clientId={clientId}");
            if (!idResponse.IsSuccessStatusCode)
                return null;

            _clientGuid = ParseClientGuidFromResponse(await idResponse.Content.ReadAsStringAsync());
            return _clientGuid;
        }
    }
}
