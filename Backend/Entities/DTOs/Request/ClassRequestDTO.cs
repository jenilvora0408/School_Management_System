using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public class ClassRequestDTO
{
    [Required]
    public int ClassId { get; set; }

    public int? ClassStrength { get; set; }

    public long? ClassTeacherId { get; set; }

    public IEnumerable<SubjectsListResponseDTO>? SubjectDetails { get; set; }
}
