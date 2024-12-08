using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;

/// <summary>
/// Represents a game stat.
/// </summary>
public record GameStat
{
    /// <summary>
    /// The API name of the stat.
    /// </summary>
    public string ApiName { get; init; }

    /// <summary>
    /// The display name of the stat.
    /// </summary>
    public string DisplayName { get; init; }

    /// <summary>
    /// The default value of the stat.
    /// </summary>
    public int DefaultValue { get; init; }
}
