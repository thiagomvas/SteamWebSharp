namespace SteamWebSharp;

/// <summary>
/// Configuration settings for the Steam API client.
/// </summary>
public record SteamApiClientConfiguration
{
    /// <summary>
    /// Gets or sets the API key used for authentication.
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// Gets or sets the default duration to cache responses. Default is 5 minutes.
    /// </summary>
    public TimeSpan DefaultCacheDuration { get; set; } = TimeSpan.FromMinutes(5);

    /// <summary>
    /// Gets or sets a value indicating whether to use the cache. Default is true.
    /// </summary>
    public bool UseCache { get; set; } = true;

    /// <summary>
    /// Gets or sets the language to use for responses. Default is "english".
    /// </summary>
    public string Language { get; set; } = "english";

    /// <summary>
    /// Gets or sets the number of retry attempts for a request before giving up. Default is 0 (throw after fail).
    /// </summary>
    public int RetryAttempts { get; set; } = 0;
}