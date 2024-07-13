using Newtonsoft.Json;

namespace ProductShop.DTOs.Export;

public class ExportSoldProductsListDto
{
    [JsonProperty("count")]
    public int Count { get; set; }


    [JsonProperty("products")]
    public List<ExportProductNamePriceDto> Products { get; set; }
}
