using Animeland.Infrastructure.Persistence;
using Animeland.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Animeland.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<AuditInterceptor>();
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                var auditInterceptor = sp.GetRequiredService<AuditInterceptor>();
                options.UseSqlServer(configuration.GetSection("DatabaseOptions:ConnectionString").Value);
                options.AddInterceptors(auditInterceptor);
            });

            return services;
        }

    }
}
