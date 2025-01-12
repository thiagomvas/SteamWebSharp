using System.Text.Json.Serialization;
using SteamWebSharp.Interfaces;

namespace SteamWebSharp.Models.Market;


/// <summary>
/// Represents a description of an asset on the Steam Market.
/// </summary>
public class AssetDescription
{
    /// <summary>
    /// The App ID of the asset.
    /// </summary>
    [JsonPropertyName("appid")]
    public int AppId { get; set; }
    
    /// <summary>
    /// The class ID of the asset.
    /// </summary>
    [JsonPropertyName("classid")]
    public string ClassId { get; set; }
    
    /// <summary>
    /// The instance ID of the asset.
    /// </summary>
    [JsonPropertyName("instanceid")]
    public string InstanceId { get; set; }
    
    /// <summary>
    /// The background color of the asset.
    /// </summary>
    [JsonPropertyName("background_color")]
    public string BackgroundColor { get; set; }
    
    /// <summary>
    /// The icon URL of the asset.
    /// </summary>
    [JsonPropertyName("icon_url")]
    public string IconUrl { get; set; }
    
    /// <summary>
    /// Whether the asset is tradable.
    /// </summary>
    [JsonPropertyName("tradable")]
    public int Tradable { get; set; }
    
    /// <summary>
    /// The name of the asset.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    /// <summary>
    /// The color of the asset name.
    /// </summary>
    [JsonPropertyName("name_color")]
    public string NameColor { get; set; }
    
    /// <summary>
    /// The type of the asset.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    /// <summary>
    /// The market hash name of the asset. Can be used in <see cref="ISteamMarket.GetPriceHistoryForItemAsync"/> and <see cref="ISteamMarket.GetPriceOverviewForItemAsync"/>
    /// </summary>
    [JsonPropertyName("market_hash_name")]
    public string MarketHashName { get; set; }
    
    /// <summary>
    /// The market name of the asset.
    /// </summary>
    [JsonPropertyName("market_name")]
    public string MarketName { get; set; }
    
    /// <summary>
    /// Whether the asset is marketable.
    /// </summary>
    [JsonPropertyName("commodity")]
    public int Commodity { get; set; }
    
    /// <summary>
    /// The sale price text of the asset.
    /// </summary>
    [JsonPropertyName("sale_price_text")]
    public string SalePriceText { get; set; }
    
    
}