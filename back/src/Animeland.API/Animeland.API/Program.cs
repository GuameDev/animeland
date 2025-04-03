using Animeland.API.Extensions.ServiceCollectionExtensions;
using Animeland.API.Extensions.WebApplicationBuilderExtensions;
using Animeland.API.Options;

namespace Animeland.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}
