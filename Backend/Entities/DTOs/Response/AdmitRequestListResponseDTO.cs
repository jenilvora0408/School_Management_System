namespace Entities.DTOs;

public record AdmitRequestListResponseDTO
{
    public string Name { get; init; } = null!;

    public string Email { get; init; } = null!;

    public string? ClassName { get; init; }

    public string RequestedRole { get; init; } = null!;
}
