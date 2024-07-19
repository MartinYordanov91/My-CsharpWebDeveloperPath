using Castle.Components.DictionaryAdapter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Data;

namespace CarDealer.DTOs.Export;

public class ExportOrderedCustomerDto
{
   
    public string Name { get; set; } = null!;


    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime BirthDate { get; set; }

    public bool IsYoungDriver { get; set; }
}
