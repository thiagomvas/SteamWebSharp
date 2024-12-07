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

    public ISteamUser ISteamUser { get; }
    public ISteamUserStats ISteamUserStats { get; }
    public SteamApiClient(string apiKey)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient { BaseAddress = new Uri("https://api.steampowered.com") };

        ISteamUser = new SteamUserEndpoints(this);
        ISteamUserStats = new SteamUserStatsEndpoints(this);
    }

    internal protected async Task<T> GetAsync<T>(string endpoint)
    {
        var url = $"{endpoint}&key={_apiKey}";
        var response = await _httpClient.GetStringAsync(url);
        return Utils.ExtractResponse<T>(response);
    }
}
