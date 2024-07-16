namespace Entities.DTOs;

public record AdmitRequestListResponseDTO
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int ClassId { get; set; }

    public int AdmitRequestRoleId { get; set; }
}
