namespace Entities.DTOs;

public class LeaveRequestsForPrincipalDTO : LeaveRequestsListResponseDTO
{
    public long UserId { get; set; }
    
    public string Name { get; set; } = null!;
}
