using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Export;

public class ExportCarObjDto
{
    [JsonProperty("car")]
    public ExportCarObjPropDto Car { get; set; }

    [JsonProperty("parts")]
    public List<ExportPartNamePriceDto> Parts { get; set; }
}
