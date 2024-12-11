using Entities.DTOs;

namespace BusinessAccessLayer.Interface;

public interface ITeacherService
{
    Task<ViewAdmitRequestDTO> GetAdmitRequest(long id);

    Task CreateLeaveRequest(LeaveRequestDTO leaveRequestDTO);

    Task<PageListResponseDTO<LeaveRequestsListResponseDTO>> GetAllLeaveRequest(LeaveRequestsListDTO leaveRequestsListDTO);

    Task AdmitRequestApproval(AdmitRequestApprovalDTO admitRequestApprovalDTO);

    Task<LeavesCountDTO> GetLeavesCount(long userId);

    Task<SubjectTeacherInfoDTO> GetClassesForSubjectTeacher(long userId);

    Task<PageListResponseDTO<ClassSubjectChaptersPageListResponseDTO>> GetAllClassSubjectChapters(ClassSubjectPageListRequestDTO classSubjectPageListRequestDTO);

    Task<string> ManageChapterDocument(ManageChapterDocumentDTO manageChapterDocumentDTO);

    Task<GetChapterDocumentDTO> GetChapterDocument(int courseId);
}
