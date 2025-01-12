namespace SteamWebSharp.Models.Market;

public class PriceHistory
{
    public bool Success { get; set; }
    public string PricePrefix { get; set; }
    public string PriceSuffix { get; set; }
    public List<PriceRecord> Prices { get; set; }
}