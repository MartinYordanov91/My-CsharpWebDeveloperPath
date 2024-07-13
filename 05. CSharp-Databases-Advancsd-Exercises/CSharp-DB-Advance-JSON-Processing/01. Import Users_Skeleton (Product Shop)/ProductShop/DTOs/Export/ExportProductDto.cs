using Newtonsoft.Json;

namespace ProductShop.DTOs.Export;

public class ExportProductDto
{
    [JsonProperty("name")]
    public string ProductName { get; set; }

    [JsonProperty("price")]
    public decimal Price { get; set; }

    [JsonProperty("buyerFirstName")]
    public string BuyerFirstName { get; set; }

    [JsonProperty("buyerLastName")]
    public string BuyerLastName { get; set; }
}
