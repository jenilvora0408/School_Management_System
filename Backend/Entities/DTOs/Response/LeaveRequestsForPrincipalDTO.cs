namespace Entities.DTOs;

public class LeaveRequestsAwaitingApprovalDTO : LeaveRequestsListResponseDTO
{
    public long UserId { get; set; }
    
    public string Name { get; set; } = null!;
}
