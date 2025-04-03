using Animeland.API.Options;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Animeland.API.Extensions.ServiceCollectionExtensions
{
    public static class SwaggerConfigurationExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(appSettings.Swagger.Version, new OpenApiInfo
                {
                    Title = appSettings.Swagger.Title,
                    Version = appSettings.Swagger.Version,
                    Description = appSettings.Swagger.Description
                });
            });

            return services;
        }

        public static WebApplication UseSwaggerDocumentation(this WebApplication app)
        {
            var swaggerOptions = app.Services.GetRequiredService<IOptions<SwaggerOptions>>().Value;

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });

            return app;
        }
    }
}
