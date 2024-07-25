namespace Entities.DTOs;

public record ViewAdmitRequestDTO
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string GenderTitle { get; set; } = null!;

    public string? Avatar { get; set; }

    public string BloodGroupTitle { get; set; } = null!;

    public string RequestedRoleTitle { get; set; } = null!;

    public string? ClassName { get; set; }

    public string? MediumTitle { get; set; }

    public int ApprovalStatus { get; set; }

    public string? Comment { get; set; }

    public string? ApprovedByName { get; set; }

    public string? DeclinedByName { get; set; }

    public string? BlockedByName { get; set; }
}
