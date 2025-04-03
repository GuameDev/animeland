namespace Animeland.API.Extensions.ServiceCollectionExtensions
{
    public static class RegisterApiServicesExtension
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();


            // CORS (will configure later)
            services.AddCors();
            return services;
        }
    }
}
