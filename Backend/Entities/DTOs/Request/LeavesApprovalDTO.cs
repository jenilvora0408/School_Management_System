using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public class LeavesApprovalDTO
{
    [Required]
    public long LeaveId { get; set; }

    [Required]
    public byte ApprovalStatus { get; set; }
}
