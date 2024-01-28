using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace UnityNexus.Client
{
    public partial class Program
    {
        public static string DefaultHttpClientName = "DefaultHttp";

        private const string AnonymousClientName = "Anonymous";

        public static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Application...");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            AddHttpClients(builder);
            AddServices(builder.Services, builder.Configuration, builder.HostEnvironment.BaseAddress);


            WebAssemblyHost host = builder.Build();
            Console.WriteLine("Build successful...");
            await host.RunAsync();
        }

        private static void AddHttpClients(WebAssemblyHostBuilder builder)
        {
        }

        private static void AddServices(
            IServiceCollection services,
            IConfiguration configuration,
            string baseAddress
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
    }
}
