using SteamWebSharp.DTOs.TeamFortress;
using SteamWebSharp.Interfaces;
using SteamWebSharp.Models.TeamFortress;

namespace SteamWebSharp;

public class TeamFortressEndpoints : ITeamFortress
{
    private readonly SteamApiClient _client;

    public TeamFortressEndpoints(SteamApiClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<GetPlayerItemsResponse>> GetPlayerItemsAsync(ulong steamId)
    {
        var url = "/IEconItems_440/GetPlayerItems/v1/?steamid=76561198379450830";
        var response = await _client.GetAsync<GetPlayerItemsResponse>(url);
        return [response];
        var result = response.items.Select(i =>
        {
            return new TeamFortressPlayerItem
            {
                Id = i.id,
                OriginalId = i.original_id,
                Defindex = i.defindex,
                Level = i.level,
                Quality = i.quality,
                CustomName = i.custom_name,
                CustomDescription = i.custom_desc,
                Inventory = i.inventory,
                Quantity = i.quantity,
                Origin = i.origin,
                Attributes = i.attributes.Select(a =>
                {
                    return new TeamFortressItemAttribute
                    {
                        Defindex = a.defindex,
                        Value = a.value,
                        FloatValue = a.float_value,
                        IsOutput = a.is_output,
                        Quantity = a.quantity,
                        Quality = a.quality,
                        MatchAllAttribs = a.match_all_attribs,
                        Itemdef = a.itemdef
                    };
                }).ToArray()
            };
        }).ToArray();
    }
}