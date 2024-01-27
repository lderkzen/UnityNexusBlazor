using Microsoft.AspNetCore.Components;

namespace UnityNexus.Client.Extensions
{
    internal static class NavigationManagerExtensions
    {
        internal static string GetHostName(this NavigationManager navigationManager)
        {
            return new Uri(navigationManager.BaseUri).Host;
        }
    }
}
