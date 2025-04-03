using Animeland.API.Options;

namespace Animeland.API.Extensions.ServiceCollectionExtensions
{
    public static class ConfigureAppOptionsExtension
    {
        public static IServiceCollection AddAppOptions(this IServiceCollection services, IConfiguration configuration)
        {
            // Bind and register each strongly typed options object here
            services.Configure<SwaggerOptions>(configuration.GetSection(nameof(SwaggerOptions)));

            return services;
        }
    }
}
