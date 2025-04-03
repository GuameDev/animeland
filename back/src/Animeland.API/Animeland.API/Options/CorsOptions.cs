namespace Animeland.API.Options
{
    public class CorsOptions
    {
        public const string PolicyName = "FrontendClient";
        public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
    }
}
