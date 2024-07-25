namespace Entities.DTOs;

public record AdmitRequestListResponseDTO
{
    public long Id { get; init; }

    public string Name { get; init; } = null!;

    public string Email { get; init; } = null!;

    public string PhoneNumber { get; init; } = null!;

    public string? ClassName { get; init; }

    public string RequestedRole { get; init; } = null!;

    public int ApprovalStatus { get; init; }
}
