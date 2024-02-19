namespace UnityNexus.Server.Extensions
{
    internal static class ConfigurationExtensions
    {
        /// <summary>
        /// Gets the connection for the given name from the configuration, and performs decoding, if necessary.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="name">The name of the connection string.</param>
        /// <returns>The final connection string.</returns>
        internal static string GetDynamicConnectionString(
            this IConfiguration configuration,
            string name
        )
        {
            const string base64Prefix = "base64:";

            var connectionString = configuration.GetConnectionString(name);
            if (!connectionString!.StartsWith(base64Prefix, StringComparison.Ordinal))
                return connectionString;

            connectionString = connectionString.Replace(base64Prefix, string.Empty);
            // Ensure that the padding is correct.
            connectionString = connectionString.PadRight(connectionString.Length + (4 - connectionString.Length % 4) % 4, '=');

            var decodedBytes = Convert.FromBase64String(connectionString);
            return Encoding.UTF8.GetString(decodedBytes);
        }
    }
}
