using Entities.DTOs;

namespace BusinessAccessLayer.Interface;

public interface IPrincipalService
{
    Task UpsertClasses(ClassRequestDTO classRequestDTO, CancellationToken cancellationToken);

    Task<List<SubjectsListResponseDTO>> GetSubjectsByClass(int classId);

    Task<PageListResponseDTO<LeaveRequestsListResponseDTO>> GetAllLeaveRequest(PageListRequestDTO leaveRequestsListDTO);
}
