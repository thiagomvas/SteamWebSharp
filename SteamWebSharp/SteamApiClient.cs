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

    public TimeSpan DefaultCacheDuration { get; set; } = TimeSpan.FromMinutes(5);
    public bool UseCache { get; set; } = true;

    internal string ApiKey => _apiKey;

    /// <summary>
    /// Endpoints for the ISteamUser interface.
    /// </summary>
    public ISteamUser ISteamUser { get; }
    /// <summary>
    /// Endpoints for the ISteamUserStats interface.
    /// </summary>
    public ISteamUserStats ISteamUserStats { get; }
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
    }

    internal protected async Task<T> GetAsync<T>(string endpoint)
    {
        var url = $"{endpoint}&key={_apiKey}";
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
