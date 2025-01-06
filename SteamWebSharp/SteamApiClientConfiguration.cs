namespace SteamWebSharp;

public record SteamApiClientConfiguration
{
    public string ApiKey { get; set; }
    public TimeSpan DefaultCacheDuration { get; set; } = TimeSpan.FromMinutes(5);
    public bool UseCache { get; set; } = true;
    public string Language { get; set; } = "english";
}