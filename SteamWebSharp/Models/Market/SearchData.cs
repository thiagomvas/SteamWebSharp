using System.Text.Json.Serialization;

namespace SteamWebSharp.Models.Market;

public class SearchData
{
    public string Query { get; set; }
    [JsonPropertyName("search_descriptions")]
    public bool SearchDescriptions { get; set; }
    [JsonPropertyName("total_count")]
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public string Prefix { get; set; }
    [JsonPropertyName("class_prefix")]
    public string ClassPrefix { get; set; }
}