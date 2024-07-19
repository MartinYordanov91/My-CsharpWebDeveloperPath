using Newtonsoft.Json;

namespace CarDealer.DTOs.Import;

public class ImportSaleDto
{
    [JsonProperty("carId")]
    public int CarId { get; set; }


    [JsonProperty("customerId")]
    public int CustomerId { get; set; }


    [JsonProperty("discount")]
    public int Discount { get; set; }
}
