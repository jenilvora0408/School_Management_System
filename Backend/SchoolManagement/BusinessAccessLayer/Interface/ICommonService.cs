using Entities.DataModels;
using Entities.DTOs.Common;

namespace BusinessAccessLayer.Interface
{
    public interface ICommonService
    {
        Task<CommonEntityListResponseDto> GetEntityList();
    }
}
