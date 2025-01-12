using System.Text.Json.Serialization;

namespace SteamWebSharp.Models.Market;

/// <summary>
/// Represents an item in the Steam Market search results.
/// </summary>
public class MarketSearchResult
{
    /// <summary>
    /// The name of the item.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    /// <summary>
    /// The hash name of the item.
    /// </summary>
    [JsonPropertyName("hash_name")]
    public string HashName { get; set; }
    
    /// <summary>
    /// How many sell listings there are for this item.
    /// </summary>
    [JsonPropertyName("sell_listings")]
    public int SellListings { get; set; }
    
    /// <summary>
    /// The sell price of the item.
    /// </summary>
    [JsonPropertyName("sell_price")]
    public double SellPrice { get; set; }
    
    /// <summary>
    /// The sell price of the item formatted.
    /// </summary>
    [JsonPropertyName("sell_price_text")]
    public string SellPriceText { get; set; }
    
    /// <summary>
    /// The icon of the app that owns the item.
    /// </summary>
    [JsonPropertyName("app_icon")]
    public string AppIcon { get; set; }
    
    /// <summary>
    /// The name of the app that owns the item.
    /// </summary>
    [JsonPropertyName("app_name")]
    public string AppName { get; set; }
    
    /// <summary>
    /// An object describing the item in the market.
    /// </summary>
    [JsonPropertyName("asset_description")]
    public AssetDescription AssetDescription { get; set; }
    
    
    
    
}