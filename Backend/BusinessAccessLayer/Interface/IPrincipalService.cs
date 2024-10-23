using Entities.DTOs;

namespace BusinessAccessLayer.Interface;

public interface IPrincipalService
{
    Task UpsertClasses(ClassRequestDTO classRequestDTO, CancellationToken cancellationToken);

    Task<List<SubjectsListResponseDTO>> GetSubjectsByClass(int classId);

    Task<PageListResponseDTO<LeaveRequestsAwaitingApprovalDTO>> GetAllLeaveRequest(PageListRequestDTO leaveRequestsListDTO);

    Task<PageListResponseDTO<GetContactPrincipalListDTO>> GetContactPrincipalList(PageListRequestDTO pageListRequestDTO);

    Task<List<string>> GetContactPrincipalDocuments(int contactPrincipalId);

    Task PostContactPrincipalResponse(ContactPrincipalResponseDTO contactPrincipalResponseDTO);
}
