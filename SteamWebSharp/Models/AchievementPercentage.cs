using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;

/// <summary>
/// Represents the percentage of players who have unlocked an achievement.
/// </summary>
public record AchievementPercentage
{
    /// <summary>
    /// The API name of the achievement.
    /// </summary>
    public string ApiName { get; init; }

    /// <summary>
    /// The percentage of players who have unlocked the achievement.
    /// </summary>
    public double Percentage { get; init; }
}
