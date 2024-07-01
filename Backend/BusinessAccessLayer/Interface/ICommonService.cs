using Entities.DataModels;

namespace BusinessAccessLayer.Interface;

public interface ICommonService
{
    Task<User?> GetUserByEmail(string email);
}
