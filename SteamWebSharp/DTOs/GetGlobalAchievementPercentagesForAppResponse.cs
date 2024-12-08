using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp.DTOs;
internal class GetGlobalAchievementPercentagesForAppResponse
{
    public AchievementPercentages AchievementPercentages { get; set; }
}

internal class AchievementPercentages
{
    public AchievementPercentageDto[] achievements { get; set; }
}

internal class AchievementPercentageDto
{
    public string name { get; set; }
    public double percent { get; set; }
}