namespace Entities.DTOs;

public class ManageChapterDocumentDTO
{
    public int? CourseId { get; set; }

    public int? DocumentId { get; set; }

    public string? DocumentContent { get; set; }
}