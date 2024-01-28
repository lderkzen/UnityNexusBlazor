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

            await builder.Build().RunAsync();
		}
	}
}
