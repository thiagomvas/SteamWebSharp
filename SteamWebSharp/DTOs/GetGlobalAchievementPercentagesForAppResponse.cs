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