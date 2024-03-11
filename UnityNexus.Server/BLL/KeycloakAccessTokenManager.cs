namespace UnityNexus.Server.BLL
{
    public class KeycloakAccessTokenManager : IKeycloakAccessTokenManager
    {
        private readonly string _accessTokenBaseAddress;
        private readonly string _accessTokenRoute;
        private readonly Uri _accessTokenUrl;
        private readonly FormUrlEncodedContent _accessTokenRequestContent;
        // private readonly ILogger<KeycloakAccessTokenManager> _logger;

        private Task<bool>? _newTokenTask;
        private (JwtSecurityToken Token, AuthenticationHeaderValue Header) _accessData;

        public KeycloakAccessTokenManager(KeycloakInstallationOptions keycloakInstallationOptions)
        {
            _accessTokenBaseAddress = keycloakInstallationOptions.AuthServerUrl;
            _accessTokenRoute = $"realms/{keycloakInstallationOptions.Realm}/protocol/openid-connect/token";
            _accessTokenUrl = new Uri(_accessTokenBaseAddress + _accessTokenRoute);
            _accessTokenRequestContent = CreateAccessTokenRequestContent(keycloakInstallationOptions);
            // _logger = logger;
            _accessData = (new JwtSecurityToken(), new AuthenticationHeaderValue("Bearer"));
        }

        private static FormUrlEncodedContent CreateAccessTokenRequestContent(KeycloakInstallationOptions keycloakInstallationOptions)
        {
            var values = new Dictionary<string, string>
        {
            {"grant_type", "client_credentials"},
            {"client_id", keycloakInstallationOptions.Resource},
            {"client_secret", keycloakInstallationOptions.Credentials.Secret},
        };
            return new FormUrlEncodedContent(values);
        }

        private async Task<AuthenticationHeaderValue?> GetAuthHeaderValueAsync(HttpClient httpClient)
        {
            // Check if token expires within the next 10 seconds.
            if (_accessData.Token.ValidTo > DateTime.UtcNow.AddSeconds(10))
                return _accessData.Header;

            // Get new token, once.
            _ = Interlocked.CompareExchange(ref _newTokenTask, TryGetNewAccessTokenAsync(httpClient), null);
            var success = await _newTokenTask;
            _newTokenTask = null;
            return success
                       ? _accessData.Header
                       : null;
        }

        private async Task<bool> TryGetNewAccessTokenAsync(HttpClient httpClient)
        {
            HttpResponseMessage response;
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, _accessTokenUrl) { Content = _accessTokenRequestContent };
                request.Headers.Add("cache-control", "no-cache");
                response = await httpClient.SendAsync(request);
            }
            catch (HttpRequestException e)
            {
                var baseExceptionMessage = e.GetBaseException().Message;
                // _logger.LogRequestError(_accessTokenBaseAddress, _accessTokenRoute, baseExceptionMessage);
                return false;
            }

            if (!response.IsSuccessStatusCode)
            {
                // await _logger.LogRequestErrorAsync(_accessTokenBaseAddress, _accessTokenRoute, response);
                return false;
            }

            var content = await response.Content.ReadAsStreamAsync();
            var jsonContent = await JsonDocument.ParseAsync(content);
            var tokenResponse = OAuthTokenResponse.Success(jsonContent);
            if (tokenResponse.AccessToken is null)
            {
                // await _logger.LogRequestErrorAsync(_accessTokenBaseAddress, _accessTokenRoute, response);
                return false;
            }

            _accessData = (new JwtSecurityToken(tokenResponse.AccessToken),
                           new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken));

            return true;
        }

        async Task IKeycloakAccessTokenManager.SetAccessTokenAsync(HttpClient httpClient)
        {
            var header = await GetAuthHeaderValueAsync(httpClient);
            if (header is null)
            {
                // _logger.LogError("Failed to get Keycloak access token");
                return;
            }

            httpClient.DefaultRequestHeaders.Authorization = header;
        }
    }
}
