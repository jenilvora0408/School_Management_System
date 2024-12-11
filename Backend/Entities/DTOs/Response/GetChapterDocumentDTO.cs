namespace Entities.DTOs;

public class GetChapterDocumentDTO
{
    public long DocumentId { get; set; }

    public string DocumentContent { get; set; } = null!;

    public int? CourseId { get; set; }

    public string UseDocumentFor { get; set; } = null!;
}
