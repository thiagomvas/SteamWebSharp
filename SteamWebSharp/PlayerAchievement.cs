using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;
public record PlayerAchievement
{
    public string ApiName { get; set; }
    public bool Achieved { get; set; }
    public DateTime? UnlockTime { get; set; }
}
