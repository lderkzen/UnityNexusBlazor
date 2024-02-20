using UnityNexus.Server.Shared;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

namespace UnityNexus.Server.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection ConfigureForwardedHeadersOptions(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            // See https://stackoverflow.com/a/44390593/2132796 for details about network configuration.
            // This is required when hosting UNITS behind a reverse proxy like Caddy.
            var networkSection = configuration.GetSection("Network");
            var networkPrefix = networkSection["NetworkPrefix"];
            var proxy = networkSection["Proxy"];
            if (!string.IsNullOrEmpty(networkPrefix) && !string.IsNullOrEmpty(proxy))
            {
                services.Configure<ForwardedHeadersOptions>(options =>
                {
                    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                    options.KnownNetworks.Clear();
                    options.KnownNetworks.Add(new Microsoft.AspNetCore.HttpOverrides.IPNetwork(IPAddress.Parse(networkPrefix), 24));
                    options.KnownProxies.Clear();
                    options.KnownProxies.Add(IPAddress.Parse(proxy));
                });
            }

            return services;
        }

        internal static IServiceCollection AddUnityNexusContext(this IServiceCollection services)
        {
            services.AddDbContext<UnityNexusContext>(options =>
            {
                options.UseNpgsql(string.Format(
                    "Server={0};Port={1};User ID={2};Password={3};Database={4}",
                    DotEnv.Generated.DatabaseEnvironment.UnityNexusDbHost,
                    DotEnv.Generated.DatabaseEnvironment.UnityNexusDbPort,
                    DotEnv.Generated.DatabaseEnvironment.UnityNexusDbUsername,
                    DotEnv.Generated.DatabaseEnvironment.UnityNexusDbPassword,
                    DotEnv.Generated.DatabaseEnvironment.UnityNexusDbName
                ));
#if DEBUG
                options.EnableSensitiveDataLogging();
#endif
            });

            return services;
        }

        internal static IServiceCollection AddAppConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IAppConfigurationStore, AppConfigurationStore>();
            return services;
        }

        internal static IServiceCollection AddStores(this IServiceCollection services)
        {
            services.AddScoped<IGroupStore, GroupStore>();
            services.AddScoped<ITagStore, TagStore>();

            return services;
        }
    }
}
