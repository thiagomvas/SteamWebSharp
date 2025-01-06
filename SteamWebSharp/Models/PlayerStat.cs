using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;

/// <summary>
/// Represents a player's stat in a game.
/// </summary>
public record PlayerStat
{
    /// <summary>
    /// The API name of the stat.
    /// </summary>
    public string ApiName { get; set; }

    /// <summary>
    /// The value for the stat.
    /// </summary>
    public ulong Value { get; set; }
}
