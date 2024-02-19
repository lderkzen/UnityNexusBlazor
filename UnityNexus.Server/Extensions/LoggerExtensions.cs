using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace UnityNexus.Server.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogRequestError(
            this ILogger logger,
            string baseAddress,
            string route,
            string reason
        )
        {
            logger.LogWarning("Failed to call '{HttpAddress}{Route}': {Reason}", baseAddress, route, reason);
        }

        public static async Task LogRequestErrorAsync(
            this ILogger logger,
            string baseAddress,
            string route,
            HttpResponseMessage responseMessage
        )
        {
            HttpStatusCode statusCode = responseMessage.StatusCode;
            string responseMessageContent = string.Empty;

            try
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(content))
                    responseMessageContent = content;
            }
            catch
            {
                responseMessageContent = string.Empty;
            }

            logger.LogWarning(
                "Failed to call '{HttpAddress}{Route}': {Reason} {HttpStatusCodeName} {HttpStatusCode} {ResponseMessageContent}",
                baseAddress,
                route,
                "HTTP Status Code",
                statusCode.ToString(),
                (int)statusCode,
                responseMessageContent
            );
        }
    }
}
