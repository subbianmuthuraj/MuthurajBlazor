namespace Entities.ConfigurationModels;

public class JwtConfiguration
{
    public string Section { get; set; } = "JwtSettings";
    public string SecurityKey { get; set; }
    public string? ValidIssuer { get; set; }
    public string? ValidAudience { get; set; }
    public string? ExpiryInMinutes { get; set; }
}
