using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp.DTOs;
internal class GetSchemaForGameResponse
{
    public string GameName { get; set; }
    public string GameVersion { get; set; }
    public AvailableGameStatsDto AvailableGameStats { get; set; }
}

public class AvailableGameStatsDto
{
    public GameAchievementDto[] Achievements { get; set; }
    public GameStatDto[] Stats { get; set; }
}

public class GameAchievementDto
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public int Hidden { get; set; }
    public string Icon { get; set; }
    public string IconGray { get; set; }
    public int DefaultValue { get; set; }
}

public class GameStatDto
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public int DefaultValue { get; set; }
}
