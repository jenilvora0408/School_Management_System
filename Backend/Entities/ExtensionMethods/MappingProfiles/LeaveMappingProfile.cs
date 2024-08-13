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
}
