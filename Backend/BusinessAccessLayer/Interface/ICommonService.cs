using Entities.DataModels;
using Entities.DTOs;

namespace BusinessAccessLayer.Interface;

public interface ICommonService
{
    Task<User?> GetUserByEmail(string email);

    Task<CommonEntityListResponseDTO> GetEntityList();

    Task<PageListResponseDTO<AdmitRequestListResponseDTO>> GetAdmitRequestsList(PageListRequestDTO admitRequestList);
}
