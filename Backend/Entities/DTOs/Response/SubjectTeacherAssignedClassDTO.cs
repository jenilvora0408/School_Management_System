namespace Entities.DTOs;

public class SubjectTeacherAssignedClassDTO
{
    public string ClassName { get; set; } = null!;

    public long ClassTeacherId { get; set; }

    public string ClassTeacherName { get; set; } = null!;

    public int ClassStrength { get; set; }

    public int ClassId { get; set; }
}
