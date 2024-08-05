using Entities.DataModels;
using Entities.DTOs;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class AdmitRequestMappingProfile
{
    public static AdmitRequest ToAdmitRequest(this AdmitRequestDTO admitRequestDTO) => new()
    {
        FirstName = admitRequestDTO.FirstName,
        LastName = admitRequestDTO.LastName,
        Email = admitRequestDTO.Email,
        Address = admitRequestDTO.Address,
        PhoneNumber = admitRequestDTO.PhoneNumber,
        GenderId = admitRequestDTO.GenderId,
        Avatar = admitRequestDTO.Avatar,
        DateOfBirth = admitRequestDTO.DateOfBirth,
        BloodGroupId = admitRequestDTO.BloodGroupId,
        ClassId = admitRequestDTO.ClassId,
        MediumId = admitRequestDTO.MediumId,
        AdmitRequestRoleId = admitRequestDTO.AdmitRequestRoleId,
        ApprovalStatus = 1,
    };

    public static ViewAdmitRequestDTO ToGetAdmitRequest(this AdmitRequest admitRequest)
    {
        return new ViewAdmitRequestDTO
        {
            Id = admitRequest.Id,
            Name = admitRequest.FirstName + " " + admitRequest.LastName,
            Email = admitRequest.Email,
            Address = admitRequest.Address,
            PhoneNumber = admitRequest.PhoneNumber,
            DateOfBirth = admitRequest.DateOfBirth,
            GenderTitle = admitRequest.Genders.Title,
            Avatar = admitRequest.Avatar,
            BloodGroupTitle = admitRequest.BloodGroups.Title,
            RequestedRoleTitle = admitRequest.AdmitRequestRoles.Title,
            ClassName = admitRequest.Classes?.ClassName ?? string.Empty,
            MediumTitle = admitRequest.Mediums?.Title ?? string.Empty,
            ApprovalStatus = admitRequest.ApprovalStatus,
            Comment = admitRequest.Comment,
            ApprovedByName = admitRequest.ApprovedByUser?.FirstName + ' ' + admitRequest.ApprovedByUser?.LastName ?? string.Empty,
            DeclinedByName = admitRequest.DeclinedByUser?.FirstName + ' ' + admitRequest.DeclinedByUser?.LastName ?? string.Empty,
            BlockedByName = admitRequest.BlockedByUser?.FirstName + ' ' + admitRequest.BlockedByUser?.LastName ?? string.Empty,
        };
    }

    public static AdmitRequestListResponseDTO ToAdmitRequestListResponseDTO(this AdmitRequest admitRequest)
    {
        return new AdmitRequestListResponseDTO
        {
            Name = $"{admitRequest.FirstName} {admitRequest.LastName}",
            Email = admitRequest.Email,
            PhoneNumber = admitRequest.PhoneNumber,
            ClassName = admitRequest.Classes != null ? admitRequest.Classes.ClassName : null,
            RequestedRole = admitRequest.AdmitRequestRoles.Title
        };
    }

    public static List<AdmitRequestListResponseDTO> ToAdmitRequestListResponseDTOs(this IEnumerable<AdmitRequest> admitRequests)
    {
        return admitRequests.Select(admitRequest => admitRequest.ToAdmitRequestListResponseDTO()).ToList();
    }

    public static void ToApproveAdmitRequest(this AdmitRequestApprovalDTO admitRequestDTO, AdmitRequest admitRequest)
    {
        admitRequest.Id = admitRequestDTO.AdmitRequestId;
        admitRequest.ApprovalStatus = admitRequestDTO.ApprovalStatus;
        admitRequest.Comment = admitRequestDTO.Comment;
        admitRequest.ApprovedBy = admitRequestDTO.ApprovedBy == 0 ? null : admitRequestDTO.ApprovedBy;
        admitRequest.DeclinedBy = admitRequestDTO.DeclinedBy == 0 ? null : admitRequestDTO.DeclinedBy;
        admitRequest.BlockedBy = admitRequestDTO.BlockedBy == 0 ? null : admitRequestDTO.BlockedBy;
        admitRequest.ReasonForBlock = admitRequestDTO.ReasonForBlock;
    }
}
