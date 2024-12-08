using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;
public record PlayerStats
{
    public ulong SteamId { get; init; }
    public string GameName { get; init; }
    public PlayerAchievement[] Achievements { get; init; }
    public PlayerStat[] Stats { get; init; }
    public bool Success { get; init; }
}
