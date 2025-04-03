using Animeland.API.Extensions.ServiceCollectionExtensions;
using Animeland.API.Options;

namespace Animeland.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Centralized app options
            builder.Services.AddAppOptions(builder.Configuration);

            var swaggerOptions = new SwaggerOptions();
            builder.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            // Core API services
            builder.Services.AddApiServices();

            // Swagger config
            builder.Services.AddSwaggerDocumentation(swaggerOptions);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}
