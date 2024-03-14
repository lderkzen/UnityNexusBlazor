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

        internal static IServiceCollection AddDiagnostics(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            string connectionString = string.Format(
                "Server={0};Port={1};User ID={2};Password={3};Database={4}",
                DotEnv.Generated.DatabaseEnvironment.UnityNexusDbHost,
                DotEnv.Generated.DatabaseEnvironment.UnityNexusDbPort,
                DotEnv.Generated.DatabaseEnvironment.UnityNexusDbUsername,
                DotEnv.Generated.DatabaseEnvironment.UnityNexusDbPassword,
                DotEnv.Generated.DatabaseEnvironment.UnityNexusDbName
            );

            services.AddHealthChecks()
                .AddNpgSql(
                    connectionString,
                    "SELECT 1;",
                    null,
                    HealthCheckedServices.PostgresDatabase,
                    HealthStatus.Unhealthy,
                    ["db", "sql", "pgsql", "postgres", "postgresql"]
                )
                .AddDbContextCheck<UnityNexusContext>(
                    HealthCheckedServices.EntityFrameworkAccess,
                    HealthStatus.Unhealthy,
                    ["db", "ef", "ef-core"],
                    async (context, token) => await context.ConfigurationEntries.AnyAsync(token)
                );

            return services;
        }

        internal static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            KeycloakAuthenticationOptions options = new();
            configuration
                .GetSection(KeycloakAuthenticationOptions.Section)
                .Bind(options, opt => opt.BindNonPublicProperties = true);

            services.AddSingleton<KeycloakInstallationOptions>(options);
            services.AddKeycloakAuthentication(
                options,
                bearerOptions =>
                {
                    bearerOptions.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            StringValues accessToken = context.Request.Query["access_token"];
                            PathString path = context.HttpContext.Request.Path;
                            if (
                                !string.IsNullOrEmpty(accessToken) &&
                                (path.StartsWithSegments("/user-hub") || path.StartsWithSegments("/bot-hub"))
                            )
                            {
                                context.Token = accessToken;
                            }

                            return Task.CompletedTask;
                        }
                    };
                }
            );

            return services;
        }

        internal static IServiceCollection AddCookiePolicy(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            return services;
        }

        internal static IServiceCollection AddStores(this IServiceCollection services)
        {
            services.AddScoped<ICategoryStore, CategoryStore>();
            services.AddScoped<IGroupStore, GroupStore>();
            services.AddScoped<ITagStore, TagStore>();

            return services;
        }

        internal static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
        {

            services.AddSingleton<IClaimsPrincipalHandler, ClaimsPrincipalHandler>();
            services.AddSingleton<IKeycloakAccessTokenManager, KeycloakAccessTokenManager>();
            return services;
        }
    }
}
