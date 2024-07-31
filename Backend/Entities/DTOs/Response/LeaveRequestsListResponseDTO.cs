namespace Entities.DTOs;

public class LeaveRequestsListResponseDTO
{
    public long Id { get; init; }

    public string ReasonForLeave { get; init; } = null!;

    public DateTime StartDate { get; init; }

    public DateTime EndDate { get; init; }

    public string LeaveStartType { get; init; } = null!;

    public string LeaveEndType { get; init; } = null!;

    public string LeaveDuration { get; init; } = null!;

    public string LeaveType { get; init; } = null!;

    public byte ApprovalStatus { get; init; }
}