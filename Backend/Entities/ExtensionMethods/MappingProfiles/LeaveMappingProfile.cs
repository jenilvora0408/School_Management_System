using Entities.DataModels;
using Entities.DTOs;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class LeaveMappingProfile
{
    public static Leave ToCreateTeacherLeaveRequest(this LeaveRequestDTO leaveRequestDTO, byte ApprovalFromUser) => new()
    {
        UserId = leaveRequestDTO.LeaveRequestorId,
        ApprovalFromUserId = ApprovalFromUser,
        ReasonForLeave = leaveRequestDTO.ReasonForLeave,
        ApprovalStatus = Convert.ToByte(1),
        StartDate = leaveRequestDTO.StartDate,
        EndDate = leaveRequestDTO.EndDate,
        LeaveDuration = leaveRequestDTO.LeaveDuration,
        LeaveType = leaveRequestDTO.LeaveType,
        AlternatePhoneNumber = leaveRequestDTO.AlternatePhoneNumber
    };

    public static LeavesCountDTO ToGetLeavesCount(int totalLeavesCount, int pendingRequestsCount, int approvedLeavesCount, int declinedLeavesCount, int remainingLeavesCount, int sickLeavesCount) => new()
    {
        TotalRequestsCount = totalLeavesCount,
        PendingRequestsCount = pendingRequestsCount,
        ApprovedRequestsCount = approvedLeavesCount,
        DeclinedRequestCount = declinedLeavesCount,
        LeavesRemainingCount = remainingLeavesCount,
        SickLeavesCount = sickLeavesCount
    };

    public static List<LeaveRequestsAwaitingApprovalDTO> ToGetLeavesForPrincipal(this List<Leave> leaves)
    {
        return leaves.Select(leave => leave.ToGetLeavesData()).ToList();
    }

    public static LeaveRequestsAwaitingApprovalDTO ToGetLeavesData(this Leave leave)
    {
        return new LeaveRequestsAwaitingApprovalDTO
        {
            Id = leave.Id,
            ReasonForLeave = leave.ReasonForLeave,
            StartDate = leave.StartDate,
            EndDate = leave.EndDate,
            LeaveDuration = leave.LeaveDuration,
            LeaveType = leave.LeaveType,
            ApprovalStatus = leave.ApprovalStatus,
            AlternatePhoneNumber = leave.AlternatePhoneNumber,
            PhoneNumber = leave.Users?.PhoneNumber?? string.Empty,
            UserId = leave.UserId,
            Name = leave.Users?.FirstName + ' ' + leave.Users?.LastName
        };
    }

    public static void ToApproveOrDeclineLeave(this LeavesApprovalDTO leavesApprovalDTO, Leave leave)
    {
        leave.ApprovalStatus = leavesApprovalDTO.ApprovalStatus;
    }
}
