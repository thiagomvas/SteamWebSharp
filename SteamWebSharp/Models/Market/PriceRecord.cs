namespace SteamWebSharp.Models.Market;

public class PriceRecord
{
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public int Volume { get; set; }
}