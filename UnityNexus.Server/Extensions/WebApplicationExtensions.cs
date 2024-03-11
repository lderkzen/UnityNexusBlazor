namespace UnityNexus.Server.Extensions
{
    internal static class WebApplicationExtensions
    {
        private static void ConfigureEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecks("/health", new HealthCheckOptions
            {
                AllowCachingResponses = true
            });
            endpoints.MapDefaultControllerRoute();
        }

        internal static WebApplication ConfigureRequestPipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
                app.UseHttpsRedirection();
            }
            else
            {
                app.UseResponseCompression();
                app.UseForwardedHeaders();
                app.UseHsts();
            }

            app.UseSecurityHeaders(collection => collection.Configure(app.Environment.IsDevelopment()));

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            // TODO
            if (app.Environment.IsDevelopment())
            {
                //app.UseOpenApi();
                //app.UseSwaggerUi3();
                //app.UseReDoc(options =>
                //{
                //    options.Path = "/redoc";
                //    options.DocumentPath = "/swagger/client-api/swagger.json";
                //});
            }

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseCors();
            // app.UseAuthentication();
            // app.UseAuthorization();

            app.UseEndpoints(ConfigureEndpoints);

            return app;
        }
    }
}
