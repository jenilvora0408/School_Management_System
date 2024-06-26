using Entities.DataModels;
using Entities.DTOs;

namespace BusinessAccessLayer.Interface;

public interface IUserService : IBaseService<User>
{
    Task CreateAdmitRequest(AdmitRequestDTO admitRequestDTO, CancellationToken cancellationToken);
}
