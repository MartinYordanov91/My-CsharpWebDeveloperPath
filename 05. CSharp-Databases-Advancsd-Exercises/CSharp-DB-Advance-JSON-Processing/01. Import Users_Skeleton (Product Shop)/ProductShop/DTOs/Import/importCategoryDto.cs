using Newtonsoft.Json;

namespace ProductShop.DTOs.Import;

public class importCategoryDto
{
    [JsonProperty("name")]
    public string? Name { get; set; }
}
