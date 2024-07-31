using Entities.DTOs;

namespace BusinessAccessLayer.Interface;

public interface ITeacherService
{
    Task<ViewAdmitRequestDTO> GetAdmitRequest(long id);

    Task CreateLeaveRequest(LeaveRequestDTO leaveRequestDTO);

    Task<PageListResponseDTO<LeaveRequestsListResponseDTO>> GetAllLeaveRequest(LeaveRequestsListDTO leaveRequestsListDTO);

    Task AdmitRequestApproval(AdmitRequestApprovalDTO admitRequestApprovalDTO);
}
