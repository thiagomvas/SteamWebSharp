using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;
public record Friend
{
    public string SteamId { get; set; }
    public string Relationship { get; set; }
    public DateTime FriendSince { get; set; }
}
