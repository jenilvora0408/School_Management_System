using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public class LeaveRequestDTO
{
    public long LeaveRequestorId { get; set; }

    [Required]
    public string ReasonForLeave { get; set; } = null!;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public string LeaveStartType { get; set; } = null!;

    [Required]
    public string LeaveEndType { get; set; } = null!;

    [Required]
    public string LeaveDuration { get; set; } = null!;

    [Required]
    public string LeaveType { get; set; } = null!;

    public bool? AvailabilityOnPhone { get; set; }

    public string? AlternatePhoneNumber { get; set; }
}
