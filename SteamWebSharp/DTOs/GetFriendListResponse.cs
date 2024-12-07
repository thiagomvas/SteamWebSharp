using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp.DTOs;
internal class GetFriendListResponse
{
    public FriendDto[] Friends { get; set; }
}

internal class FriendDto
{
    public string steamid { get; set; }
    public string relationship { get; set; }
    public long friend_since { get; set; }
}
