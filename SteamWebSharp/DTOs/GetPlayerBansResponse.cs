﻿namespace SteamWebSharp.DTOs;

internal class GetPlayerBansResponse
{
    public PlayerBansDto[] Players { get; set; }
}

internal class PlayerBansDto
{
    public string SteamId { get; set; }
    public bool CommunityBanned { get; set; }
    public bool VACBanned { get; set; }
    public int NumberOfVACBans { get; set; }
    public int DaysSinceLastBan { get; set; }
    public int NumberOfGameBans { get; set; }
    public string EconomyBan { get; set; }
}