using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("District")]
public class importDistrictDto
{

    [Required]
    [MaxLength(80)]
    [MinLength(2)]
    [XmlElement("Name")]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(8)]
    [MinLength(8)]
    [RegularExpression(@"^[A-Z]{2}-\d{5}$")]
    [XmlElement("PostalCode")]
    public string PostalCode { get; set; } = null!;

    [Required]
    [XmlAttribute("Region")]
    public string Region { get; set; } 

    [XmlArray("Properties")]
    public ImportPropertyDto[] Properties { get; set; } = null!;
}
