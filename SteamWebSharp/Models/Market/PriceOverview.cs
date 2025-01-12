using System.Text.Json.Serialization;

namespace SteamWebSharp.Models.Market;

public record PriceOverview
{
    public bool Success { get; init; }
    /// <summary>
    /// The current lowest price of the item.
    /// </summary>
    [JsonPropertyName("lowest_price")]
    public string LowestPrice { get; set; }
    
    /// <summary>
    /// The current median price of the item.
    /// </summary>
    [JsonPropertyName("median_price")]
    public string MedianPrice { get; set; }
    
    /// <summary>
    /// The number of items that has been sold in the last 24 hours.
    /// </summary>
    /// <remarks>
    /// Does not exist if the value is 0.
    /// </remarks>
    public string Volume { get; set; }
    
}