namespace SteamWebSharp.Models.TeamFortress;

public class TeamFortressPlayerItem
{
    public long Id { get; set; }
    public long OriginalId { get; set; }
    public long Defindex { get; set; }
    public int Level { get; set; }
    public int Quality { get; set; }
    public string CustomName { get; set; }
    public string CustomDescription { get; set; }
    public long Inventory { get; set; }
    public int Quantity { get; set; }
    public int Origin { get; set; }
    public TeamFortressItemAttribute[] Attributes { get; set; }
}