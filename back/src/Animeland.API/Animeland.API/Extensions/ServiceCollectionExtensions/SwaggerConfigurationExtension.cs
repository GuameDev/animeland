using Animeland.API.Options;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Animeland.API.Extensions.ServiceCollectionExtensions
{
    public static class SwaggerConfigurationExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, SwaggerOptions swaggerOptions)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(swaggerOptions.Version, new OpenApiInfo
                {
                    Title = swaggerOptions.Title,
                    Version = swaggerOptions.Version,
                    Description = swaggerOptions.Description
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
