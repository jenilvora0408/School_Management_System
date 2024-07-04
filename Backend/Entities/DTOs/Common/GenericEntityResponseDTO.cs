namespace Entities.DTOs.Common;

public record GenericEntityResponseDTO
{
    public byte Id { get; set; }

    public string? Title { get; set; }
}
