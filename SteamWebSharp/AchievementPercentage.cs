using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;
public record AchievementPercentage
{
    public string ApiName { get; set; }
    public double Percentage { get; set; }
}
