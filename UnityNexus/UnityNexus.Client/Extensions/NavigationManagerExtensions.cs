using Microsoft.AspNetCore.Components;

namespace UnityNexus.Client.Extensions
{
    public static class NavigationManagerExtensions
    {
        public static string GetHostName(this NavigationManager navigationManager)
        {
            return new Uri(navigationManager.BaseUri).Host;
        }
    }
}
