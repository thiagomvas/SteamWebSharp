using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp.DTOs;
internal class GetPlayerAchievementsResponse
{
    public PlayerStatsDto PlayerStats { get; set; }
}

internal class PlayerStatsDto
{
    public string SteamId { get; set; }
    public string GameName { get; set; }
    public List<PlayerAchievementDto> Achievements { get; set; }
    public List<PlayerStatDto> Stats { get; set; }
    public bool Success { get; set; }
}

internal class PlayerAchievementDto
{
    public string ApiName { get; set; }
    public string Name { get; set; }
    public int Achieved { get; set; }
    public ulong UnlockTime { get; set; }
}

internal class PlayerStatDto
{
    public string Name { get; set; }
    public ulong Value { get; set; }
}