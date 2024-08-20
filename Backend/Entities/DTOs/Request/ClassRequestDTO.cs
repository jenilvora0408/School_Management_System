namespace Entities.DTOs;

public class ClassRequestDTO
{
    public int? ClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public int? ClassStrength { get; set; }

    public long? ClassTeacherId { get; set; }
}
