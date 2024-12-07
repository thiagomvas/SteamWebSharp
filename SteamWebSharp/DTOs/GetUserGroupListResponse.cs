using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp.DTOs;
internal class GetUserGroupListResponse
{
    public GroupDto[] Groups { get; set; }
}

internal class GroupDto
{
    public string Gid { get; set; }
}
