using System.Net;

namespace UnityNexus.Shared.Extensions
{
    public static class HttpStatusCodeExtensions
    {
        public static string Format(this HttpStatusCode statusCode) => $"HTTP {(int)statusCode} {statusCode}";
    }
}
