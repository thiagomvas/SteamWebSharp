namespace SteamWebSharp.Models;

public class OwnedGame
{
    public int AppId { get; set; }
    public string Name { get; set; }
    public int PlaytimeForever { get; set; }
    public string ImgIconUrl { get; set; }
    public bool HasCommunityVisibleStats { get; set; }
    public int PlaytimeWindowsForever { get; set; }
    public int PlaytimeMacForever { get; set; }
    public int PlaytimeLinuxForever { get; set; }
    public int PlaytimeDeckForever { get; set; }
    public DateTime LastPlayed { get; set; }
    public string CapsuleFileName { get; set; }
    public bool HasWorkshop { get; set; }
    public bool HasMarket { get; set; }
    public bool HasDlc { get; set; }
    public int PlaytimeDisconnected { get; set; }
    public bool HasLeaderboards { get; set; }
    public int Playtime2Weeks { get; set; }
}