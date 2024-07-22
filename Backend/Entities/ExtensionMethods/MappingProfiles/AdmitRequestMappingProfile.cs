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
}
