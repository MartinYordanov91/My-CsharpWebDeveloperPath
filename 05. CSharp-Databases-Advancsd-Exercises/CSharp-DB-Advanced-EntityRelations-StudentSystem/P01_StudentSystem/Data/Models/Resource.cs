using P01_StudentSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models;

public class Resource
{
    public int ResourceId { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = null!;


    public string Url { get; set; } = null!;

    public ResourceType ResourceType { get; set; }

    [Required]
    public int CourseId { get; set; }

    [ForeignKey(nameof(CourseId))]
    public virtual Course Course { get; set; }
}
