using Entities.DataModels;
using Entities.DTOs;

namespace BusinessAccessLayer.Interface;

public interface ICommonService
{
    Task<User?> GetUserByEmail(string email);

    Task<User?> GetUserById(long id);

    Task<CommonEntityListResponseDTO> GetEntityList();

    Task<PageListResponseDTO<AdmitRequestListResponseDTO>> GetAdmitRequestsList(PageListRequestDTO admitRequestList);

    Task<List<ClassesListResponseDTO>> GetAllClasses();

    Task<IEnumerable<TeachersListResponseDTO>> GetAllTeachers();

    Task<IEnumerable<SubjectsListResponseDTO>> GetAllSubjects();

    Task<GetUserProfileDTO> GetUserProfile(long userId);

    Task UpdateUserProfile(GetUserProfileDTO getUserProfileDTO);

    Task<string> LeaveRequestApproval(LeavesApprovalDTO leavesApprovalDTO);

    Task ContactPrincipalRequest(ContactPrincipalDTO contactPrincipalDTO);
}
