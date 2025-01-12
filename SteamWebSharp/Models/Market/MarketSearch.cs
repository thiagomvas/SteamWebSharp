using System.Text.Json.Serialization;

namespace SteamWebSharp.Models.Market;

/// <summary>
/// Represents a search result from the Steam Market.
/// </summary>
public class MarketSearch
{
    /// <summary>
    /// Whether the search was successful or not.
    /// </summary>
    public bool Success { get; set; }
    
    /// <summary>
    /// The start index of the search.
    /// </summary>
    public int Start { get; set; }
    
    /// <summary>
    /// The number of results per page.
    /// </summary>
    public int Pagesize { get; set; }
    
    /// <summary>
    /// The search data.
    /// </summary>
    public SearchData SearchData { get; set; }
    
    /// <summary>
    /// The total count of results.
    /// </summary>
    [JsonPropertyName("total_count")]
    public int TotalCount { get; set; }
    
    /// <summary>
    /// The results of the search.
    /// </summary>
    public MarketSearchResult[] Results { get; set; }
}