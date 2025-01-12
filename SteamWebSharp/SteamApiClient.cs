using Microsoft.Extensions.Logging;
using SteamWebSharp.Interfaces;

namespace SteamWebSharp;

/// <summary>
///     A client for getting data using the Steam Web API.
/// </summary>
public class SteamApiClient
{
    private readonly ISteamApiClientCacheProvider _cacheProvider;
    protected readonly HttpClient _httpClient;
    private readonly ILogger<SteamApiClient>? _logger;
    private string _authCookie;
    private ISteamNews _iSteamNews;
    private ISteamUser _iSteamUser;
    private ISteamUserStats _iSteamUserStats;
    private ISteamMarket _iSteamMarket;
    private SteamApiClientConfiguration _configuration;

    /// <summary>
    ///     Initializes a new instance of the <see cref="SteamApiClient" /> class with the specified API key.
    /// </summary>
    /// <param name="apiKey">The API key to use for requests.</param>
    public SteamApiClient(SteamApiClientConfiguration configuration) : this(configuration, new SteamApiClientDefaultCacheProvider())
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="SteamApiClient" /> class with the specified API key, cache provider,
    ///     and logger.
    /// </summary>
    /// <param name="apiKey">The API key to use for requests.</param>
    /// <param name="cacheProvider">The cache provider to use for caching responses.</param>
    /// <param name="logger">The logger to use for logging information.</param>
    public SteamApiClient(SteamApiClientConfiguration configuration, ISteamApiClientCacheProvider cacheProvider,
        ILogger<SteamApiClient>? logger = null)
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("https://api.steampowered.com") };
        _cacheProvider = cacheProvider;
        _logger = logger;
        _configuration = configuration;
        ISteamUser = new SteamUserEndpoints(this);
        ISteamUserStats = new SteamUserStatsEndpoints(this);
        ISteamNews = new SteamNewsEndpoints(this);
        ISteamMarket = new SteamMarketEndpoints(this);
    }
    

    /// <summary>
    ///     Gets the API key.
    /// </summary>
    internal string ApiKey => _configuration.ApiKey;

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
    
    public ISteamMarket ISteamMarket
    {
        get => _iSteamMarket;
        set
        {
            _logger?.LogInformation($"{nameof(ISteamMarket)} provider set to {value.GetType().Name}");
            _iSteamMarket = value;
        }
    }

    /// <summary>
    /// Gets or sets the authentication cookie to use for requests.
    /// </summary>
    /// <remarks>
    /// This is sensitive information and should be kept secure, be careful when setting this value to avoid leaking it.
    /// </remarks>
    public string AuthCookie
    {
        get => _authCookie;
        set
        {
            _authCookie = value;
            _httpClient.DefaultRequestHeaders.Remove("Cookie");
            _httpClient.DefaultRequestHeaders.Add("Cookie", value);
        }
    }

    /// <summary>
    ///     Sends a GET request to the specified endpoint and returns the response deserialized to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response to.</typeparam>
    /// <param name="endpoint">The endpoint to send the GET request to.</param>
    /// <returns>The deserialized response.</returns>
    protected internal async Task<T> GetAsync<T>(string endpoint, bool authed = true)
    {
        int retryCount = 0;
        bool hasParams = endpoint.Contains('?');
        var url = authed ? $"{endpoint}{(hasParams ? "&" : "?")}key={_configuration.ApiKey}&l={_configuration.Language}" : endpoint;
        var cachedResult = _cacheProvider.Get<T>(url);
        if (cachedResult != null) return cachedResult;
    
        while (true)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(url);
                var result = Utils.ExtractResponse<T>(response);
                if (_configuration.UseCache)
                    _cacheProvider.Set(url, result, _configuration.DefaultCacheDuration);
    
                return result;
            }
            catch (Exception ex) when (retryCount < _configuration.RetryAttempts)
            {
                retryCount++;
                _logger?.LogWarning(ex, "Failed to get response from {Url}. Retrying... ({RetryCount}/{MaxRetries})", 
                    url, 
                    retryCount, 
                    _configuration.RetryAttempts);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Failed to get response from {Url}.", url);
                throw; 
            }
        }
    }

}