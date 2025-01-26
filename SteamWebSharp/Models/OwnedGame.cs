using System.Text.Json.Serialization;

namespace SteamWebSharp.Models;

public class OwnedGame
{
    public int AppId { get; set; }
    public string Name { get; set; }
    [JsonPropertyName("playtime_forever")]
    public int PlaytimeForever { get; set; }
    [JsonPropertyName("img_icon_url")]
    public string ImgIconUrl { get; set; }
    [JsonPropertyName("has_community_visible_stats")]
    public bool HasCommunityVisibleStats { get; set; }
    [JsonPropertyName("playtime_windows_forever")]
    public int PlaytimeWindowsForever { get; set; }
    [JsonPropertyName("playtime_mac_forever")]
    public int PlaytimeMacForever { get; set; }
    [JsonPropertyName("playtime_linux_forever")]
    public int PlaytimeLinuxForever { get; set; }
    [JsonPropertyName("playtime_deck_forever")]
    public int PlaytimeDeckForever { get; set; }
    [JsonPropertyName("last_played")]
    public DateTime LastPlayed { get; set; }
    [JsonPropertyName("capsule_file_name")]
    public string CapsuleFileName { get; set; }
    [JsonPropertyName("has_workshop")]
    public bool HasWorkshop { get; set; }
    [JsonPropertyName("has_market")]
    public bool HasMarket { get; set; }
    [JsonPropertyName("has_dlc")]
    public bool HasDlc { get; set; }
    [JsonPropertyName("playtime_disconnected")]
    public int PlaytimeDisconnected { get; set; }
    [JsonPropertyName("has_leaderboards")]
    public bool HasLeaderboards { get; set; }
    [JsonPropertyName("playtime_2weeks")]
    public int Playtime2Weeks { get; set; }
}
