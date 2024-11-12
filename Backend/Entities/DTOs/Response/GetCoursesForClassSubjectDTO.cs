namespace Entities.DTOs;

public class GetCoursesForClassSubjectDTO
{
    public int CourseId { get; set; }

    public int ChapterSerialNumber { get; set; }

    public string ChapterName { get; set; } = null!;

    public int? ProbableWeightageInExam { get; set; }

    public string? ProbableDurationToTeach { get; set; }

    public bool IsOptionalToTeach { get; set; }

    public string? LearningObjectives { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public string ClassName { get; set; } = null!;

    public string SubjectName { get; set; } = null!;
}
