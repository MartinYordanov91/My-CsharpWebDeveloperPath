using Newtonsoft.Json;

namespace ProductShop.DTOs.Export;

public class ExportProductNamePriceDto
{
    [JsonProperty("name")]
    public string ProductName { get; set; } = null!;


    [JsonProperty("price")]
    public decimal Price { get; set; }
}

