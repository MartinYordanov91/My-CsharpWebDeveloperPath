using Newtonsoft.Json;

namespace ProductShop.DTOs.Export;

public class ExportUserListDto
{
    [JsonProperty("usersCount")]
    public int UsersCount { get; set; }

    [JsonProperty("users")]
    public List<ExportUserProductInfoDto> Users { get; set; }
}
