using SteamWebSharp.Interfaces;
using SteamWebSharp.Models.Market;

namespace SteamWebSharp;

public class SteamMarketEndpoints : ISteamMarket
{
    private readonly SteamApiClient _client;
    
    public SteamMarketEndpoints(SteamApiClient client)
    {
        _client = client;
    }
    public async Task<PriceOverview> GetPriceOverviewForItemAsync(int appId, string marketHashName, Currency currency = Currency.USD,
        string countryCode = "US")
    {
        var url =
            $"https://steamcommunity.com/market/priceoverview/?country={countryCode}&currency={(int)currency}&appid={appId}&market_hash_name={marketHashName}";
        
        return await _client.GetAsync<PriceOverview>(url);  
    }

    public Task<PriceHistory> GetPriceHistoryForItemAsync(int appId, string marketHashName)
    {
        var encodedMarketHashName = Uri.EscapeDataString(marketHashName);
        var url =
            $"https://steamcommunity.com/market/pricehistory?appid=730&market_hash_name=AWP%20%7C%20Dragon%20Lore%20%28Factory%20New%29";
        
        return _client.GetAsync<PriceHistory>(url, false);
    }

    public Task<MarketSearch> SearchMarketAsync(int appId, string query, int count = 99, bool searchDescriptions = false)
    {
        var url = $"https://steamcommunity.com/market/search/render?norender=1&appid={appId}&start=0&count=99&query={query}&count={count}&search_descriptions={searchDescriptions}";
        return _client.GetAsync<MarketSearch>(url);
    }
}