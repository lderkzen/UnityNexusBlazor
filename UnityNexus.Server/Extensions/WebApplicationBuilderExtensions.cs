using Microsoft.AspNetCore.Mvc.ModelBinding;
using UnityNexus.Shared.Enums;

namespace UnityNexus.Server.Extensions
{
    internal static class WebApplicationBuilderExtensions
    {
        private static Error[] TransformModelStateToErrors(in ModelStateDictionary.ValueEnumerable modelState)
        {
            List<Error> result = [];
            foreach (ModelStateEntry? mse in modelState)
            {
                TryAddError(mse);
            }

            return result.ToArray();

            void TryAddError(ModelStateEntry? mse)
            {
                if (mse is null
                 || mse.ValidationState != ModelValidationState.Invalid)
                    return;

                result.AddRange(
                    mse.Errors.Select(msError =>
                        new Error(
                            ErrorClassification.InvalidOperation,
                            msError.ErrorMessage
                        )
                    )
                );

                if (mse.Children is null)
                    return;

                foreach (var mseChild in mse.Children)
                    TryAddError(mseChild);
            }
        }

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
