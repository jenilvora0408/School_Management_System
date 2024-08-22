namespace Entities.DTOs;

public class ClassesListResponseDTO
{
    public int ClassId { get; init; }

    public string ClassName { get; init; } = null!;

    public int? ClassStrength { get; init; }

    public string? ClassTeacherName { get; init; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }
}
