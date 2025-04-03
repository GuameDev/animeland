namespace Animeland.API.Options;

public class AppSettings
{
    public SwaggerOptions Swagger { get; set; } = new();
    public CorsOptions Cors { get; set; } = new();
    public DatabaseOptions Database { get; set; } = new();
}
