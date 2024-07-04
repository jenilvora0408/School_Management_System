using Entities.DataModels;
using Entities.DTOs.Common;

namespace BusinessAccessLayer.Interface;

public interface ICommonService
{
    Task<User?> GetUserByEmail(string email);

    Task<CommonEntityListResponseDTO> GetEntityList();
}
