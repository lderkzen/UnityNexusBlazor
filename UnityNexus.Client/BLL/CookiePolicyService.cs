using Blazored.LocalStorage;

namespace UnityNexus.Client.BLL
{
    public class CookiePolicyService : ICookiePolicyService
    {
        private const string CookieConsentGivenUntilKey = "cookieConsentGivenUntil";

        private readonly ILocalStorageService _localStorageService;

        public CookiePolicyService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public event EventHandler? AcceptedCookiePolicy;

        async Task<bool> ICookiePolicyService.CheckIfCookieConsentIsRequiredAsync()
        {
            var containsCookieConsent = await _localStorageService.ContainKeyAsync(CookieConsentGivenUntilKey);
            if (!containsCookieConsent)
                return true;

            var cookieConsentGivenUntil = await _localStorageService.GetItemAsync<DateTime>(CookieConsentGivenUntilKey);
            return cookieConsentGivenUntil <= DateTime.Today;
        }

        async Task ICookiePolicyService.SetConsentCookieAsync()
        {
            var r = new Random();
            var randomDays = r.Next(-7, 7);
            var oneYear = DateTime.Today.AddYears(1).AddDays(randomDays);
            await _localStorageService.SetItemAsync(CookieConsentGivenUntilKey, oneYear);
            AcceptedCookiePolicy?.Invoke(this, EventArgs.Empty);
        }
    }
}
