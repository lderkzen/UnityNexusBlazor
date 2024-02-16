using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

namespace UnityNexus.Server.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddStores(this IServiceCollection services)
        {
            services.AddScoped<IGroupStore, GroupStore>();

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
            });

            return services;
        }
    }
}
