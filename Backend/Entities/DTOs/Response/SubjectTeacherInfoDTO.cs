namespace Entities.DTOs;

public class SubjectTeacherInfoDTO
{
    public string TeacherName { get; set; } = null!;

    public int? SubjectId { get; set; }

    public string? SubjectName { get; set; }

    public List<SubjectTeacherAssignedClassDTO>? SubjectTeacherAssignedClasses { get; set; }
}
