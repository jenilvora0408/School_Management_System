namespace Entities.DTOs;

public class DocumentDTO
{
    public string DocumentContent { get; set; } = null!;

    public string? DocumentName { get; set; }

    public string? DocumentType { get; set; }

    public string? DocumentExtension { get; set; }
}
