using System.Text.Json.Serialization;

namespace SteamWebSharp.DTOs.TeamFortress;

public class GetPlayerItemsResponse
{
    public int status { get; set; }
    public int num_backpack_slots { get; set; }
    public ItemsDto[] items { get; set; }
}

public class ItemsDto
{
    public long id { get; set; }
    public long original_id { get; set; }
    public int defindex { get; set; }
    public int level { get; set; }
    public int quality { get; set; }
    public long inventory { get; set; }
    public int quantity { get; set; }
    public int origin { get; set; }
    public int style { get; set; }
    public AttributesDto[] attributes { get; set; }
    public EquippedDto[] equipped { get; set; }
    public bool flag_cannot_trade { get; set; }
    public bool flag_cannot_craft { get; set; }
    public string custom_name { get; set; }
    public string custom_desc { get; set; }
}

public class AttributesDto
{
    public int defindex { get; set; }
    public object value { get; set; }
    public double float_value { get; set; }
    public bool is_output { get; set; }
    public int quantity { get; set; }
    public int quality { get; set; }
    public bool match_all_attribs { get; set; }
    public Attributes1Dto[] attributes { get; set; }
    public int itemdef { get; set; }
}

public class Attributes1Dto
{
    public int defindex { get; set; }
    public int value { get; set; }
    public int float_value { get; set; }
}

public class EquippedDto
{
    [JsonPropertyName("class")] public int _class { get; set; }

    public int slot { get; set; }
}