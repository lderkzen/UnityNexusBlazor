namespace UnityNexus.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();

            Client.Program.AddCommonServices(builder.Services, builder.Configuration);
            ConfigureServices(builder, Configuration.Load());

            // WebApplication app = builder.Build().ConfigureRequestPipeline();
            WebApplication app = builder.Build();

            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.Run();
        }

        internal static void ConfigureServices(
            WebApplicationBuilder builder,
            IConfiguration configuration
        )
        {
            builder.Configuration.AddConfiguration(configuration);

            builder.Services
                // .AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped)
                .AddUnityNexusContext()
                // .AddDiagnostics(configuration)
                .AddCookiePolicy()
                .AddAppConfiguration()
                // .AddAuthentication(configuration)
                // .AddAuthorizationCore(options => options.AddSharedPolicies(typeof(Policies)))
                .AddStores()
                // .AddBusinessLogicLayer()
                .AddHttpClient(
                    "keycloak",
                    (provider, client) =>
                    {
                        JwtBearerOptions? jwtBearerOptions = provider.GetRequiredService<IOptionsMonitor<JwtBearerOptions>>()
                            .Get(JwtBearerDefaults.AuthenticationScheme);
                        client.BaseAddress = new Uri(jwtBearerOptions.Authority!);
                    }
                );
        }
    }
}
