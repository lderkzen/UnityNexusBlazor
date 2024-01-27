using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using UnityNexus.Client.BLL;
using UnityNexus.Client.Interfaces;

namespace UnityNexus.Client
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);

            // Add external services
            builder.Services.AddBlazoredLocalStorage();

            // Add custom services
            builder.Services.AddScoped<ICookiePolicyService, CookiePolicyService>();

            builder.Services.AddBlazorise(options =>
                {
                    options.Immediate = true;
                })
                .AddBootstrap5Providers()
                .AddFontAwesomeIcons();

            builder.Services.AddBlazoredLocalStorage();

            await builder.Build().RunAsync();
		}
	}
}
