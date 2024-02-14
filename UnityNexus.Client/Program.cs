using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Polly.Extensions.Http;
using Polly;

namespace UnityNexus.Client
{
    public partial class Program
    {
        public const string DefaultHttpClientName = "DefaultHttp";

        private const string AnonymousClientName = "Anonymous";

        public static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Application...");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            AddHttpClients(builder);

            AddHttpClients(builder);
            AddServices(builder.Services, builder.Configuration, builder.HostEnvironment.BaseAddress);

            WebAssemblyHost host = builder.Build();
            Console.WriteLine("Build successful...");
            await host.RunAsync();
        }

        private static void AddHttpClients(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddHttpClient(
                DefaultHttpClientName,
                options => options.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            )
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>()
            .AddPolicyHandler(GetRetryPolicy());
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(DefaultHttpClientName));

            builder.Services
               .AddHttpClient(AnonymousClientName,
                              options => options.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
               .AddPolicyHandler(GetRetryPolicy());

            IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
            {
                return HttpPolicyExtensions.HandleTransientHttpError()
                    .WaitAndRetryAsync(
                        6,
                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                    );
            }
        }

        public static void AddCommonServices(
            IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddBlazorise(options =>
                {
                    options.Immediate = true;
                })
                .AddBootstrap5Providers()
                .AddFontAwesomeIcons();

            services.AddBlazoredLocalStorage();
            services.AddScoped<ICookiePolicyService, CookiePolicyService>();
        }

        private static void AddServices(
            IServiceCollection services,
            IConfiguration configuration,
            string baseAddress
        )
        {
            AddCommonServices(services, configuration);

            // External dependencies
            services.AddOidcAuthentication(options =>
            {
                configuration.Bind("Oidc", options);
                Console.WriteLine($"Base Address: '{baseAddress}'");
                options.ProviderOptions.PostLogoutRedirectUri = baseAddress;
                options.ProviderOptions.AdditionalProviderParameters.Add("kc_idp_hint", "discord");
            })
                .AddAccountClaimsPrincipalFactory<KeycloakUserFactory>();
            services.AddAuthorizationCore(options => options.AddSharedPolicies(typeof(Policies)));

            AddRuntimeCaches(services);
        }

        private static void AddRuntimeCaches(IServiceCollection services)
        {

        }
    }
}
