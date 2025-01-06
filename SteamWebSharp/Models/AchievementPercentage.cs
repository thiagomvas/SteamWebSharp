namespace SteamWebSharp.Models;

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
