using Newtonsoft.Json;

namespace ProductShop.DTOs.Export;

public class ExportUserProductInfoDto
{
    [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
    public string? FirstName { get; set; }

    [JsonProperty("lastName",  NullValueHandling= NullValueHandling.Ignore)]
    public string? LastName { get; set; }

    [JsonProperty("age", NullValueHandling = NullValueHandling.Ignore)]
    public int? Age { get; set; }

    [JsonProperty("soldProducts")]
    public ExportSoldProductsListDto SoldProducts { get; set; }
}
