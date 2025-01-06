namespace SteamWebSharp.Models;

/// <summary>
///     Represents a Steam group.
/// </summary>
public record Group
{
    /// <summary>
    ///     The Id of the group.
    /// </summary>
    public ulong Gid { get; set; }
}