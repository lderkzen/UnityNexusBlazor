namespace HandOfUnity.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterEfContextProvider<TContext>(
            this IServiceCollection services,
            TContext context
        ) where TContext : DbContext, new()
        {
            services.AddScoped<DbContext, TContext>(_ => context);
            return services;
        }
    }
}
