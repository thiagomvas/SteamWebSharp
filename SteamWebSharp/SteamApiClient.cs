using Microsoft.Extensions.Logging;
using SteamWebSharp.Interfaces;

namespace SteamWebSharp;

/// <summary>
///     A client for getting data using the Steam Web API.
/// </summary>
public class SteamApiClient
{
    protected readonly string _apiKey;
    private readonly ISteamApiClientCacheProvider _cacheProvider;
    protected readonly HttpClient _httpClient;
    private readonly ILogger<SteamApiClient>? _logger;
    private ISteamNews _iSteamNews;
    private ISteamUser _iSteamUser;
    private ISteamUserStats _iSteamUserStats;

    /// <summary>
    ///     Initializes a new instance of the <see cref="SteamApiClient" /> class with the specified API key.
    /// </summary>
    /// <param name="apiKey">The API key to use for requests.</param>
    public SteamApiClient(string apiKey) : this(apiKey, new SteamApiClientDefaultCacheProvider())
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="SteamApiClient" /> class with the specified API key, cache provider,
    ///     and logger.
    /// </summary>
    /// <param name="apiKey">The API key to use for requests.</param>
    /// <param name="cacheProvider">The cache provider to use for caching responses.</param>
    /// <param name="logger">The logger to use for logging information.</param>
    public SteamApiClient(string apiKey, ISteamApiClientCacheProvider cacheProvider,
        ILogger<SteamApiClient>? logger = null)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient { BaseAddress = new Uri("https://api.steampowered.com") };
        _cacheProvider = cacheProvider;
        _logger = logger;
        ISteamUser = new SteamUserEndpoints(this);
        ISteamUserStats = new SteamUserStatsEndpoints(this);
        ISteamNews = new SteamNewsEndpoints(this);
    }

    /// <summary>
    ///     The default duration to cache responses for. Default is 5 minutes.
    /// </summary>
    public TimeSpan DefaultCacheDuration { get; set; } = TimeSpan.FromMinutes(5);

    /// <summary>
    ///     Whether to use the cache. Default is true.
    /// </summary>
    public bool UseCache { get; set; } = true;

    /// <summary>
    ///     The language to use for responses. Default is "english".
    /// </summary>
    /// <remarks>
    ///     This is passed directly as a query parameter to the Steam API. The available languages are defined by the Steam
    ///     API.
    /// </remarks>
    public string Language { get; set; } = "english";

    /// <summary>
    ///     Gets the API key.
    /// </summary>
    internal string ApiKey => _apiKey;

    /// <summary>
    ///     Gets or sets the ISteamUser provider.
    /// </summary>
    public ISteamUser ISteamUser
    {
        get => _iSteamUser;
        set
        {
            _logger?.LogInformation($"{nameof(ISteamUser)} provider set to {value.GetType().Name}");
            _iSteamUser = value;
        }
    }

    /// <summary>
    ///     Gets or sets the ISteamUserStats provider.
    /// </summary>
    public ISteamUserStats ISteamUserStats
    {
        get => _iSteamUserStats;
        set
        {
            _logger?.LogInformation($"{nameof(ISteamUserStats)} provider set to {value.GetType().Name}");
            _iSteamUserStats = value;
        }
    }

    /// <summary>
    ///     Gets or sets the ISteamNews provider.
    /// </summary>
    public ISteamNews ISteamNews
    {
        get => _iSteamNews;
        set
        {
            _logger?.LogInformation($"{nameof(ISteamNews)} provider set to {value.GetType().Name}");
            _iSteamNews = value;
        }
    }

    /// <summary>
    ///     Sends a GET request to the specified endpoint and returns the response deserialized to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response to.</typeparam>
    /// <param name="endpoint">The endpoint to send the GET request to.</param>
    /// <returns>The deserialized response.</returns>
    protected internal async Task<T> GetAsync<T>(string endpoint)
    {
        bool hasParams = endpoint.Contains('?');
        var url = $"{endpoint}{(hasParams ? "&" : "?")}key={_apiKey}&l={Language}";
        var cachedResult = _cacheProvider.Get<T>(url);
        if (cachedResult != null) return cachedResult;

        var response = await _httpClient.GetStringAsync(url);
        var result = Utils.ExtractResponse<T>(response);
        if (UseCache)
            _cacheProvider.Set(url, result, DefaultCacheDuration);

        return result;
    }
}