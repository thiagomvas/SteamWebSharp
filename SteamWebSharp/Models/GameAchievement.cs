namespace SteamWebSharp.Models;

/// <summary>
///     Represents a game achievement.
/// </summary>
public record GameAchievement
{
    /// <summary>
    ///     The API name of the achievement.
    /// </summary>
    public string ApiName { get; set; }

    /// <summary>
    ///     The display name of the achievement.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    ///     The description of the achievement, if there is one.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     Whether or not the achievement is hidden.
    /// </summary>
    public bool IsHidden { get; set; }

    /// <summary>
    ///     The url of the icon for the achievement when it is unlocked.
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    ///     The url of the icon for the achievement when it is locked.
    /// </summary>
    public string IconGray { get; set; }

    /// <summary>
    ///     The default value of the achievement.
    /// </summary>
    public int DefaultValue { get; set; }
}