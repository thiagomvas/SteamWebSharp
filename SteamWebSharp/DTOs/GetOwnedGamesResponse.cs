namespace SteamWebSharp.DTOs;

internal class GetOwnedGamesResponse
{
    public int game_count { get; set; }
    public Games[] games { get; set; }
}


internal class Games
{
    public int appid { get; set; }
    public string name { get; set; }
    public int playtime_forever { get; set; }
    public string img_icon_url { get; set; }
    public int playtime_windows_forever { get; set; }
    public int playtime_mac_forever { get; set; }
    public int playtime_linux_forever { get; set; }
    public int playtime_deck_forever { get; set; }
    public int rtime_last_played { get; set; }
    public string capsule_filename { get; set; }
    public bool has_workshop { get; set; }
    public bool has_market { get; set; }
    public bool has_dlc { get; set; }
    public int[] content_descriptorids { get; set; }
    public int playtime_disconnected { get; set; }
    public bool has_community_visible_stats { get; set; }
    public string sort_as { get; set; }
    public bool has_leaderboards { get; set; }
    public int playtime_2weeks { get; set; }
}

