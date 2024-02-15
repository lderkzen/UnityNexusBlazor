using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace UnityNexus.Extensions
{
    internal static class WebApplicationBuilderExtensions
    {
        internal static WebApplicationBuilder ConfigureServices(
            this WebApplicationBuilder builder,
            IConfiguration configuration
        )
        {
            builder.Configuration.AddConfiguration(configuration);

            builder.Services
                .AddUnityNexusContext()
                .AddCookiePolicy()
                .AddStores()
                .AddHttpClient(
                    "keycloak",
                    (provider, client) =>
                    {
                        JwtBearerOptions? jwtBearerOptions = provider.GetRequiredService<IOptionsMonitor<JwtBearerOptions>>()
                            .Get(JwtBearerDefaults.AuthenticationScheme);
                        client.BaseAddress = new Uri(jwtBearerOptions.Authority!);
                    }
                );

            return builder;
        }

        internal static IServiceCollection AddCookiePolicy(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            return services;
        }
    }
}
