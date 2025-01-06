using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using SteamWebSharp.Interfaces;

namespace SteamWebSharp;

public class SteamApiClientBuilder
{
    private readonly IServiceCollection _services;
    public SteamApiClientConfiguration Configuration { get; } = new SteamApiClientConfiguration();
    private ISteamUser _iSteamUser;
    private ISteamUserStats _iSteamUserStats;
    private ISteamNews _iSteamNews;

    public SteamApiClientBuilder()
    {
        _services = new ServiceCollection();
    }
    public SteamApiClientBuilder(IServiceCollection services)
    {
        _services = services;
    }
    
    public SteamApiClientBuilder WithApiKey(string apiKey)
    {
        Configuration.ApiKey = apiKey;
        return this;
    }

    public SteamApiClientBuilder AddHttpClient(Action<HttpClient> configureClient)
    {
        _services.AddHttpClient<SteamApiClient>((provider, client) =>
        {
            client.BaseAddress = new Uri("https://api.steampowered.com");
            configureClient(client);
        });
        return this;
    }
    
    public SteamApiClientBuilder UseISteamNewsProvider(ISteamNews iSteamNews)
    {
        _services.AddSingleton<ISteamNews>(iSteamNews);
        return this;
    }
    
    public SteamApiClientBuilder UseISteamUserProvider(ISteamUser iSteamUser)
    {
        _services.AddSingleton<ISteamUser>(iSteamUser);
        return this;
    }
    
    public SteamApiClientBuilder UseISteamUserStatsProvider(ISteamUserStats iSteamUserStats)
    {
        _services.AddSingleton<ISteamUserStats>(iSteamUserStats);
        return this;
    }
    
    public SteamApiClientBuilder SetCacheProvider(ISteamApiClientCacheProvider cacheProvider)
    {
        _services.AddSingleton<ISteamApiClientCacheProvider>(cacheProvider);
        return this;
    }
    
    public SteamApiClientBuilder AddLogging(Action<ILoggingBuilder> configureLogging)
    {
        _services.AddLogging(configureLogging);
        return this;
    }

    public SteamApiClient Build()
    {
        if (string.IsNullOrWhiteSpace(Configuration.ApiKey))
        {
            throw new InvalidOperationException("API key must be set.");
        }
        var provider = _services.BuildServiceProvider();
        var cacheProvider = provider.GetService<ISteamApiClientCacheProvider>() ?? new SteamApiClientDefaultCacheProvider();
        var logger = provider.GetService<ILogger<SteamApiClient>>();
        
        
        var client = new SteamApiClient(Configuration.ApiKey, cacheProvider, logger)
        {
            UseCache = Configuration.UseCache,
            DefaultCacheDuration = Configuration.DefaultCacheDuration,
            Language = Configuration.Language,
        };

        var iSteamUser = provider.GetService<ISteamUser>() ?? new SteamUserEndpoints(client);
        var iSteamUserStats = provider.GetService<ISteamUserStats>() ?? new SteamUserStatsEndpoints(client);
        var iSteamNews = provider.GetService<ISteamNews>() ?? new SteamNewsEndpoints(client);
        
        client.ISteamUser = iSteamUser;
        client.ISteamUserStats = iSteamUserStats;
        client.ISteamNews = iSteamNews;
        return client;
    }
    
}