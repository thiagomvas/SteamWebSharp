using SteamWebSharp.Models.Market;

namespace SteamWebSharp.Interfaces;

/// <summary>
/// Represents the interface for interacting with Steam Market-related API endpoints.
/// </summary>
/// <remarks>
/// This is not an official interface by Steam, but rather a way to group together the market-related endpoints.
/// <br/>
/// A few endpoints are heavily rate-limited, manually caching or using the built in <see cref="ISteamApiClientCacheProvider"/> is recommended.
/// </remarks>
public interface ISteamMarket
{
    /// <summary>
    /// Gets the price overview for an item on the Steam Market. This is rate limited to 20 requests per minute, 1000 per day.
    /// </summary>
    /// <param name="appId">The app id where this item is from</param>
    /// <param name="marketHashName">The market hash name for the item</param>
    /// <param name="currency">The currency to return results on</param>
    /// <param name="countryCode">The country code for the result.</param>
    /// <returns>A price overview for a given item in the marketplace</returns>
    /// <remarks>To get the Market Hash Name, go to any given item in the marketplace. On the URL, the full name in the URL is the <paramref name="marketHashName"/>.</remarks>
    /// <example>GetPriceOverviewForItemAsync(440, "Mann Co. Supply Crate Key", Currency.USD, "US"); </example>
    Task<PriceOverview> GetPriceOverviewForItemAsync(int appId, string marketHashName, Currency currency = Currency.USD, string countryCode = "US");

    /// <summary>
    /// Gets the price history for an item on the Steam Market. This requires an authenticated session, set the <see cref="SteamApiClient.AuthCookie"/> to a valid session.
    /// </summary>
    /// <param name="appId">The app id where this item is from</param>
    /// <param name="marketHashName">The market hash name for the item</param>
    /// <returns>The price history of said item in the currency of the authenticated user.</returns>
    Task<PriceHistory> GetPriceHistoryForItemAsync(int appId, string marketHashName);

    /// <summary>
    /// Searches the Steam Market for items matching the query.
    /// </summary>
    /// <param name="appId">The app id where this item is from</param>
    /// <param name="query">The search query</param>
    /// <param name="count">The number of results to return (default is 99, max is 100)</param>
    /// <param name="searchDescriptions">Whether to search item descriptions (default is false)</param>
    /// <returns>A search result containing items matching the query</returns>
    Task<MarketSearch> SearchMarketAsync(int appId, string query, int count = 99, bool searchDescriptions = false);
}