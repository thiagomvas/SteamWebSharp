using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;

/// <summary>
/// The schema of a game.
/// </summary>
public class GameSchema
{
    /// <summary>
    /// The name of the game.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// The version of the game.
    /// </summary>
    public string Version { get; init; }

    /// <summary>
    /// The list of achievements for the game.
    /// </summary>
    public GameAchievement[] Achievements { get; init; }

    /// <summary>
    /// The list of trackable stats for the game.
    /// </summary>
    public GameStat[] Stats { get; init; }

}
