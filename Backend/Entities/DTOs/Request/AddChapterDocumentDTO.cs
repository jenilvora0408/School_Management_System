using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public class AddChapterDocumentDTO
{
    [Required]
    public int CourseId { get; set; }

    public List<DocumentDTO> DocumentDTOs { get; set; } = [];
}
