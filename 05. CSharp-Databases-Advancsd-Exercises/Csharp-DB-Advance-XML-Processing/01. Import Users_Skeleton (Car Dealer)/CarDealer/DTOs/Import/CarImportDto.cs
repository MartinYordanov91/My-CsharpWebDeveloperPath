﻿using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Car")]
public class CarImportDto
{
    [XmlElement("make")]
    public string Make { get; set; } = null!;

    [XmlElement("model")]
    public string Model { get; set; } = null!;


    [XmlElement("traveledDistance")]
    public long TraveledDistance { get; set; }


    [XmlArray("parts")]
    public PartIdInputDto[] Parts { get; set; }
}
