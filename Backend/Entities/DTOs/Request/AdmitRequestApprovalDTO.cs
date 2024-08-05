namespace Entities.DTOs;

public class AdmitRequestApprovalDTO
{
    public long AdmitRequestId { get; set; }

    public int ApprovalStatus { get; set; }

    public string? Comment { get; set; }

    public long? ApprovedBy { get; set; }

    public long? DeclinedBy { get; set; }

    public long? BlockedBy { get; set; }

    public string? ReasonForBlock { get; set; }
}