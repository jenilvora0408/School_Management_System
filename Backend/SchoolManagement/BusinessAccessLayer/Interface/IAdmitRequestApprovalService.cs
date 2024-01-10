using Entities.DataModels;
using Entities.DTOs.Response;

namespace BusinessAccessLayer.Interface
{
    public interface IAdmitRequestApprovalService : IGenericService<AdmitRequestApproval>
    {
        Task<string> ApproveAdmitRequest(ApproveAdmitResponseDTO approveAdmitResponseDTO, long userId);
    }
}
