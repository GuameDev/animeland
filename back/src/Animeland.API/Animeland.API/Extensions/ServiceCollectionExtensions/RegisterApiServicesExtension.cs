using Animeland.API.Options;

namespace Animeland.API.Extensions.ServiceCollectionExtensions
{
    public static class RegisterApiServicesExtension
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddControllers();
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.AddProblemDetails();
            services.AddEndpointsApiExplorer();

            services.AddCors(options =>
            {
                options.AddPolicy(CorsOptions.PolicyName, policy =>
                {
                    policy.WithOrigins(appSettings.Cors.AllowedOrigins)
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            return services;
        }
    }
}
