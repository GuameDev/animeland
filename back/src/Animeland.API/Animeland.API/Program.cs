using Animeland.API.Extensions.ServiceCollectionExtensions;
using Animeland.API.Extensions.WebApplicationBuilderExtensions;
using Animeland.API.Options;
using Serilog;

namespace Animeland.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build())
                .Enrich
                .FromLogContext()
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseSerilog();

            AppSettings appSettings = builder.BuildAppSettingsOptions();

            // Core API services
            builder.Services.AddApiServices(appSettings);

            // Swagger config
            builder.Services.AddSwaggerDocumentation(appSettings);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
            }
            app.UseCors(CorsOptions.PolicyName);
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            try
            {
                Log.Information("Starting up Animeland.API...");
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }
    }
}
