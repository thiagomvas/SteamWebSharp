namespace SteamWebSharp.DTOs;


internal class ClientGetLastPlayedTimesResponse
{
    public LastPlayedGamesResponse[] games { get; set; }
}

internal class LastPlayedGamesResponse
{
    public int appid { get; set; }
    public int last_playtime { get; set; }
    public int playtime_2weeks { get; set; }
    public int playtime_forever { get; set; }
    public int first_playtime { get; set; }
    public int playtime_windows_forever { get; set; }
    public int playtime_mac_forever { get; set; }
    public int playtime_linux_forever { get; set; }
    public int playtime_deck_forever { get; set; }
    public int first_windows_playtime { get; set; }
    public int first_mac_playtime { get; set; }
    public int first_linux_playtime { get; set; }
    public int first_deck_playtime { get; set; }
    public int last_windows_playtime { get; set; }
    public int last_mac_playtime { get; set; }
    public int last_linux_playtime { get; set; }
    public int last_deck_playtime { get; set; }
    public int playtime_disconnected { get; set; }
}

