using Entities.DTOs;

namespace BusinessAccessLayer.Interface;

public interface IPrincipalService
{
    Task UpsertClasses(ClassRequestDTO classRequestDTO, CancellationToken cancellationToken);

    Task<List<SubjectsListResponseDTO>> GetSubjectsByClass(int classId);

    Task<PageListResponseDTO<LeaveRequestsAwaitingApprovalDTO>> GetAllLeaveRequest(PageListRequestDTO leaveRequestsListDTO);

    Task<PageListResponseDTO<GetContactPrincipalListDTO>> GetContactPrincipalList(PageListRequestDTO pageListRequestDTO);

    Task PostContactPrincipalResponse(ContactPrincipalResponseDTO contactPrincipalResponseDTO);

    Task UpsertCourseChapters(AddCourseDTO addCourseDto);

    Task<List<GetCoursesForClassSubjectDTO>> GetAllChapetrsForClassSubject(int classSubjectId);

    Task<PageListResponseDTO<SubjectsListResponseDTO>> GetAllSubjects(PageListRequestDTO subjectListRequestDTO);

    Task<string> ManageSubject(ManageSubjectDTO manageSubjectDTO);
}
