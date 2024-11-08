using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public class AddChaptersDTO
{
    public int CourseId { get; set; }
    
    public int ChapterSerialNumber { get; set; }

    [Required]
    [MaxLength(50)]
    public string ChapterName { get; set; } = null!;

    public int? ProbableWeightageInExam { get; set; }

    public string? ProbableDurationToTeach { get; set; }

    public bool IsOptionalToTeach { get; set; }

    [MaxLength(100)]
    public string? LearningObjectives { get; set; }
}
