using BusinessAccessLayer.Interface;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace BusinessAccessLayer.Services;

public class CommonService : ICommonService
{
    #region Constructor

    public readonly IUnitOfWork _unitOfWork;
    public CommonService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion Constructor

    #region Http_Methods

    public async Task<User?> GetUserByEmail(string email)
    {
        User? user = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(user => user.Email == email);
        return user;
    }

    #endregion Http_Methods
}

