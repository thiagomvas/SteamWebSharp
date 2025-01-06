namespace SteamWebSharp.Models;

/// <summary>
///     Represents a friend of a Steam user.
/// </summary>
public record Friend
{
    /// <summary>
    ///     The Steam ID of the friend.
    /// </summary>
    public string SteamId { get; init; }

    /// <summary>
    ///     The relationship of the friend to the user.
    /// </summary>
    public string Relationship { get; init; }

    /// <summary>
    ///     The date the user became friends with this friend.
    /// </summary>
    public DateTime FriendSince { get; init; }
}