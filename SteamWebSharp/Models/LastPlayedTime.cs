using System.Text.Json.Serialization;

namespace SteamWebSharp.Models;


public class LastPlayedTime
{
    public int Appid { get; set; }

    [JsonPropertyName("last_playtime")]
    public DateTime LastPlaytime { get; set; }

    [JsonPropertyName("playtime_2_weeks")]
    public int Playtime2Weeks { get; set; }

    [JsonPropertyName("playtime_forever")]
    public int PlaytimeForever { get; set; }

    [JsonPropertyName("first_playtime")]
    public DateTime FirstPlaytime { get; set; }

    [JsonPropertyName("playtime_windows_forever")]
    public int PlaytimeWindowsForever { get; set; }

    [JsonPropertyName("playtime_mac_forever")]
    public int PlaytimeMacForever { get; set; }

    [JsonPropertyName("playtime_linux_forever")]
    public int PlaytimeLinuxForever { get; set; }

    [JsonPropertyName("playtime_deck_forever")]
    public int PlaytimeDeckForever { get; set; }

    [JsonPropertyName("first_windows_playtime")]
    public DateTime FirstWindowsPlaytime { get; set; }

    [JsonPropertyName("first_mac_playtime")]
    public DateTime FirstMacPlaytime { get; set; }

    [JsonPropertyName("first_linux_playtime")]
    public DateTime FirstLinuxPlaytime { get; set; }

    [JsonPropertyName("first_deck_playtime")]
    public DateTime FirstDeckPlaytime { get; set; }

    [JsonPropertyName("last_windows_playtime")]
    public DateTime LastWindowsPlaytime { get; set; }

    [JsonPropertyName("last_mac_playtime")]
    public DateTime LastMacPlaytime { get; set; }

    [JsonPropertyName("last_linux_playtime")]
    public DateTime LastLinuxPlaytime { get; set; }

    [JsonPropertyName("last_deck_playtime")]
    public DateTime LastDeckPlaytime { get; set; }

    [JsonPropertyName("playtime_disconnected")]
    public int PlaytimeDisconnected { get; set; }
}
