namespace Entities.DTOs;

public class StudentsSubjectListDTO
{
    public int ClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public string? SubjectCode { get; set; }

    public long? SubjectTeacherId { get; set; }

    public string? SubjectTeacherName { get; set; }
}
