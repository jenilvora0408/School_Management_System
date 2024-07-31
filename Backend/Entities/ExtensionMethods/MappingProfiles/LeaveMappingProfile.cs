using System;
using Entities.DataModels;
using Entities.DTOs;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class LeaveMappingProfile
{
    public static Leave ToCreateTeacherLeaveRequest(this LeaveRequestDTO leaveRequestDTO) => new()
    {
        UserId = leaveRequestDTO.LeaveRequestorId,
        ApprovalFromUserId = Convert.ToInt64(1),
        ReasonForLeave = leaveRequestDTO.ReasonForLeave,
        ApprovalStatus = Convert.ToByte(1),
        StartDate = leaveRequestDTO.StartDate,
        EndDate = leaveRequestDTO.EndDate,
        LeaveStartType = leaveRequestDTO.LeaveStartType,
        LeaveEndType = leaveRequestDTO.LeaveEndType,
        LeaveDuration = leaveRequestDTO.LeaveDuration,
        LeaveType = leaveRequestDTO.LeaveType,
        AvailabilityOnPhone = leaveRequestDTO.AvailabilityOnPhone,
        AlternatePhoneNumber = leaveRequestDTO.AlternatePhoneNumber
    };
}
