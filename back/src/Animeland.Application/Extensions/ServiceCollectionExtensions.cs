using Animeland.Application.Animes.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Animeland.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IAnimeService, AnimeService>();
            return services;
        }

    }
}
