using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public class AdmitRequestApprovalDTO
{
    [Required]
    public long AdmitRequestId { get; set; }

    [Required]
    public int ApprovalStatus { get; set; }

    public string? Comment { get; set; }

    public long? ApprovedBy { get; set; }

    public long? DeclinedBy { get; set; }

    public long? BlockedBy { get; set; }

    public string? ReasonForBlock { get; set; }
}