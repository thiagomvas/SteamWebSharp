using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SteamWebSharp.Interfaces;

namespace SteamWebSharp;

/// <summary>
///     A builder class for configuring and creating instances of <see cref="SteamApiClient" />.
/// </summary>
public class SteamApiClientBuilder
{
    private readonly IServiceCollection _services;
    private ISteamNews _iSteamNews;
    private ISteamUser _iSteamUser;
    private ISteamUserStats _iSteamUserStats;

    /// <summary>
    ///     Initializes a new instance of the <see cref="SteamApiClientBuilder" /> class.
    /// </summary>
    public SteamApiClientBuilder()
    {
        _services = new ServiceCollection();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="SteamApiClientBuilder" /> class with the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to use.</param>
    public SteamApiClientBuilder(IServiceCollection services)
    {
        _services = services;
    }

    public SteamApiClientConfiguration Configuration { get; } = new();

    /// <summary>
    ///     Sets the API key to be used by the <see cref="SteamApiClient" />.
    /// </summary>
    /// <param name="apiKey">The API key.</param>
    /// <returns>The current <see cref="SteamApiClientBuilder" /> instance.</returns>
    public SteamApiClientBuilder WithApiKey(string apiKey)
    {
        Configuration.ApiKey = apiKey;
        return this;
    }

    /// <summary>
    ///     Adds an <see cref="HttpClient" /> to the service collection and configures it.
    /// </summary>
    /// <param name="configureClient">An action to configure the <see cref="HttpClient" />.</param>
    /// <returns>The current <see cref="SteamApiClientBuilder" /> instance.</returns>
    public SteamApiClientBuilder AddHttpClient(Action<HttpClient> configureClient)
    {
        _services.AddHttpClient<SteamApiClient>((provider, client) =>
        {
            client.BaseAddress = new Uri("https://api.steampowered.com");
            configureClient(client);
        });
        return this;
    }

    /// <summary>
    ///     Sets the <see cref="ISteamNews" /> provider.
    /// </summary>
    /// <param name="iSteamNews">The <see cref="ISteamNews" /> provider.</param>
    /// <returns>The current <see cref="SteamApiClientBuilder" /> instance.</returns>
    public SteamApiClientBuilder UseISteamNewsProvider(ISteamNews iSteamNews)
    {
        _services.AddSingleton<ISteamNews>(iSteamNews);
        return this;
    }

    /// <summary>
    ///     Sets the <see cref="ISteamUser" /> provider.
    /// </summary>
    /// <param name="iSteamUser">The <see cref="ISteamUser" /> provider.</param>
    /// <returns>The current <see cref="SteamApiClientBuilder" /> instance.</returns>
    public SteamApiClientBuilder UseISteamUserProvider(ISteamUser iSteamUser)
    {
        _services.AddSingleton<ISteamUser>(iSteamUser);
        return this;
    }

    /// <summary>
    ///     Sets the <see cref="ISteamUserStats" /> provider.
    /// </summary>
    /// <param name="iSteamUserStats">The <see cref="ISteamUserStats" /> provider.</param>
    /// <returns>The current <see cref="SteamApiClientBuilder" /> instance.</returns>
    public SteamApiClientBuilder UseISteamUserStatsProvider(ISteamUserStats iSteamUserStats)
    {
        _services.AddSingleton<ISteamUserStats>(iSteamUserStats);
        return this;
    }

    /// <summary>
    ///     Sets the cache provider for the <see cref="SteamApiClient" />.
    /// </summary>
    /// <param name="cacheProvider">The cache provider.</param>
    /// <returns>The current <see cref="SteamApiClientBuilder" /> instance.</returns>
    public SteamApiClientBuilder SetCacheProvider(ISteamApiClientCacheProvider cacheProvider)
    {
        _services.AddSingleton<ISteamApiClientCacheProvider>(cacheProvider);
        return this;
    }

    /// <summary>
    ///     Adds logging to the service collection and configures it.
    /// </summary>
    /// <param name="configureLogging">An action to configure logging.</param>
    /// <returns>The current <see cref="SteamApiClientBuilder" /> instance.</returns>
    public SteamApiClientBuilder AddLogging(Action<ILoggingBuilder> configureLogging)
    {
        _services.AddLogging(configureLogging);
        return this;
    }

    /// <summary>
    ///     Builds and returns a configured <see cref="SteamApiClient" /> instance.
    /// </summary>
    /// <returns>A configured <see cref="SteamApiClient" /> instance.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the API key is not set.</exception>
    public SteamApiClient Build()
    {
        if (string.IsNullOrWhiteSpace(Configuration.ApiKey))
            throw new InvalidOperationException("API key must be set.");
        var provider = _services.BuildServiceProvider();
        var cacheProvider = provider.GetService<ISteamApiClientCacheProvider>() ??
                            new SteamApiClientDefaultCacheProvider();
        var logger = provider.GetService<ILogger<SteamApiClient>>();

        var client = new SteamApiClient(Configuration, cacheProvider, logger);

        var iSteamUser = provider.GetService<ISteamUser>() ?? new SteamUserEndpoints(client);
        var iSteamUserStats = provider.GetService<ISteamUserStats>() ?? new SteamUserStatsEndpoints(client);
        var iSteamNews = provider.GetService<ISteamNews>() ?? new SteamNewsEndpoints(client);

        client.ISteamUser = iSteamUser;
        client.ISteamUserStats = iSteamUserStats;
        client.ISteamNews = iSteamNews;
        return client;
    }
}