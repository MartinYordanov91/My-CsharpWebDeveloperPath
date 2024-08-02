using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.DataProcessor.ImportDtos;

public class ImportCitizenDto
{

    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string LastName { get; set; } = null!;

    [Required]
    public string BirthDate { get; set; } = null!;

    [Required]
    [EnumDataType(typeof(MaritalStatus))]
    public string MaritalStatus { get; set; } 

    public int[] Properties { get; set; } = null!;


}
