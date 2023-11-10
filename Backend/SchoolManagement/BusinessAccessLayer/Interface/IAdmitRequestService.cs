using Entities.DataModels;
using Entities.DTOs.Request;

namespace BusinessAccessLayer.Interface
{
    public interface IAdmitRequestService : IGenericService<AdmitRequest>
    {
        Task AdmitRequest(AdmitRequestDTO admitRequestDTO);
    }
}
