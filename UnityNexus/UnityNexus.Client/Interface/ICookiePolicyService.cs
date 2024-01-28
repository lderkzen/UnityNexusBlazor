namespace UnityNexus.Client.Interface
{
    public interface ICookiePolicyService
    {
        event EventHandler? AcceptedCookiePolicy;

        Task<bool> CheckIfCookieConsentIsRequiredAsync();

        Task SetConsentCookieAsync();
    }
}
