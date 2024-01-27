namespace UnityNexus.Client.Interfaces;

public interface ICookiePolicyService
{
    event EventHandler? AcceptedCookiePolicy;

    Task<bool> CheckIfCookieConsentIsRequiredAsync();

    Task SetConsentCookieAsync();
}