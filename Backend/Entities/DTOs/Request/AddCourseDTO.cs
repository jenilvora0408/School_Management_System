namespace Entities.DTOs;

public class AddCourseDTO
{
    public int ClassSubjectId { get; set; }

    public List<AddChaptersDTO>? AddChaptersDTO { get; set; }
}
