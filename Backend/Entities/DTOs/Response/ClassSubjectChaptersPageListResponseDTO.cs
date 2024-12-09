namespace Entities.DTOs;

public class ClassSubjectChaptersPageListResponseDTO
{
    public int ChapterId { get; set; }

    public int ClassSubjectId { get; set; }

    public int ChapterSerialNumber { get; set; }

    public string ChapterName { get; set; } = null!;

    public int? ProbableWeightageInExam { get; set; }

    public string? ProbableDurationToTeach { get; set; }

    public bool IsOptionalToTeach { get; set; }
}

