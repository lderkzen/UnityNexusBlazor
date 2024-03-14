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

            WebApplication app = builder.Build().ConfigureRequestPipeline();

            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }

        internal static void ConfigureServices(
            WebApplicationBuilder builder,
            IConfiguration configuration
        )
        {
            builder.Configuration.AddConfiguration(configuration);

            builder.Services.AddControllers();
            builder.Services
                .AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped)
                .AddUnityNexusContext()
                .AddDiagnostics(configuration)
                .AddCookiePolicy()
                .AddAppConfiguration()
                .AddAuthentication(configuration)
                .AddAuthorization(options => options.AddSharedPolicies(typeof(Policies)))
                .AddStores()
                .AddBusinessLogicLayer()
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
