﻿using Newtonsoft.Json;

namespace CarDealer.DTOs.Import;

public class importCarDto
{
    public importCarDto()
    {
        this.PartsId = new List<int>();
    }


    [JsonProperty("make")]
    public string Make { get; set; } = null!;

    [JsonProperty("model")]
    public string Model { get; set; } = null!;

    [JsonProperty("traveledDistance")]
    public long TraveledDistance { get; set; }

    [JsonProperty("partsId")]
    public List<int> PartsId { get; set; }


}
