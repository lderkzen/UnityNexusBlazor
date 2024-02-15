namespace UnityNexus
{
    internal static class Configuration
    {
        internal static IConfiguration Load()
        {
            var builder = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", true, true)
                  .AddUserSecrets(typeof(Configuration).Assembly, true, true)
                  .AddEnvironmentVariables("SETTINGS_OVERRIDE_");

            return builder.Build();
        }
    }
}
