namespace Entities.DTOs;

public class SubjectsListResponseDTO
{
    public int SubjectId { get; init; }

    public string SubjectName { get; init; } = null!;

    public long? SubjectTeacherId { get; init; }

    public string? SubjectTeacherName { get; init; }

    public string? SubjectCode { get; init; }
}
