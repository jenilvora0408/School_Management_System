using Entities.DataModels;

namespace DataAccessLayer.Interface
{
    public interface IAuthenticationRepository : IGenericRepository<User>
    {
        Task<bool> IsEmailDuplicate(string email, long? userId, CancellationToken cancellationToken = default);

        Task<User> GetUserByEmail(string email);

        Task<UserRefreshTokens> GetUserRefreshTokens(string email, string refreshToken);

        Task DeleteUserRefreshToken(string email, string refreshToken);
    }
}
