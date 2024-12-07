using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;
public record GameAchievement
{
    public string ApiName { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public bool IsHidden { get; set; }
    public string Icon { get; set; }
    public string IconGray { get; set; }
    public int DefaultValue { get; set; }
}
