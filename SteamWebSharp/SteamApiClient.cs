using SteamWebSharp.DTOs;
using SteamWebSharp.Interfaces;

namespace SteamWebSharp;

/// <summary>
/// A client for getting data using the Steam Web API.
/// </summary>
public class SteamApiClient
{
    protected readonly HttpClient _httpClient;
    protected readonly string _apiKey;
    private readonly ISteamApiClientCacheProvider _cacheProvider;

    /// <summary>
    /// The default duration to cache responses for. Default is 5 minutes.
    /// </summary>
    public TimeSpan DefaultCacheDuration { get; set; } = TimeSpan.FromMinutes(5);

    /// <summary>
    /// Whether to use the cache. Default is true.
    /// </summary>
    public bool UseCache { get; set; } = true;

    /// <summary>
    /// The language to use for responses. Default is "english".
    /// </summary>
    /// <remarks>
    /// This is passed directly as a query parameter to the Steam API. The available languages are defined by the Steam API.
    /// </remarks>
    public string Language { get; set; } = "english";

    internal string ApiKey => _apiKey;

    /// <summary>
    /// Endpoints for the ISteamUser interface.
    /// </summary>
    public ISteamUser ISteamUser { get; }
    /// <summary>
    /// Endpoints for the ISteamUserStats interface.
    /// </summary>
    public ISteamUserStats ISteamUserStats { get; }
    
    public ISteamNews ISteamNews { get; }
    public SteamApiClient(string apiKey) : this(apiKey, new SteamApiClientDefaultCacheProvider())
    {
    }

    public SteamApiClient(string apiKey, ISteamApiClientCacheProvider cacheProvider)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient { BaseAddress = new Uri("https://api.steampowered.com") };
        _cacheProvider = cacheProvider;
        ISteamUser = new SteamUserEndpoints(this);
        ISteamUserStats = new SteamUserStatsEndpoints(this);
        ISteamNews = new SteamNewsEndpoints(this);
    }

    internal protected async Task<T> GetAsync<T>(string endpoint)
    {
        var url = $"{endpoint}&key={_apiKey}&l={Language}";
        var cachedResult = _cacheProvider.Get<T>(url);
        if (cachedResult != null)
        {
            return cachedResult;
        }

        var response = await _httpClient.GetStringAsync(url);
        var result = Utils.ExtractResponse<T>(response);
        if (UseCache)
            _cacheProvider.Set(url, result, DefaultCacheDuration);

        return result;
    }
}
