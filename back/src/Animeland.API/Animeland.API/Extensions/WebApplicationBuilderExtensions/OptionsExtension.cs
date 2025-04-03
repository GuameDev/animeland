using Animeland.API.Options;

namespace Animeland.API.Extensions.WebApplicationBuilderExtensions
{
    public static class OptionsExtension
    {
        public static AppSettings BuildAppSettingsOptions(this WebApplicationBuilder builder)
        {
            var appSettings = new AppSettings();
            builder.Configuration.GetSection(nameof(SwaggerOptions)).Bind(appSettings.Swagger);
            builder.Configuration.GetSection(nameof(CorsOptions)).Bind(appSettings.Cors);
            builder.Configuration.GetSection(nameof(DatabaseOptions)).Bind(appSettings.Database);

            // Register into DI for runtime use (optional)
            builder.Services.Configure<SwaggerOptions>(builder.Configuration.GetSection(nameof(SwaggerOptions)));
            builder.Services.Configure<CorsOptions>(builder.Configuration.GetSection(nameof(CorsOptions)));
            builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection(nameof(DatabaseOptions)));

            return appSettings;
        }
    }
}
