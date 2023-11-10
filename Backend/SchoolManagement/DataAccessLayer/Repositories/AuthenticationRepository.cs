using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class AuthenticationRepository : GenericRepository<User>, IAuthenticationRepository
    {
        #region Constructor

        public new readonly AppDbContext _dbContext;

        public AuthenticationRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion Constructor


        #region Methods

        public async Task<bool> IsEmailDuplicate(string email, long? userId, CancellationToken cancellationToken = default)
        => userId is null ? await AnyAsync(EmailFilter(email), cancellationToken) : await AnyAsync(EmailFilter(email, userId), cancellationToken);

        public async Task<User> GetUserByEmail(string email) => await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);

        public async Task<UserRefreshTokens> AddUserRefreshToken(UserRefreshTokens userRefreshTokens)
        {
            await _dbContext.UserRefreshTokens.AddAsync(userRefreshTokens);
            return userRefreshTokens;
        }

        public async Task<UserRefreshTokens> GetUserRefreshTokens(string email, string refreshToken)    
        {
            return await _dbContext.UserRefreshTokens.FirstOrDefaultAsync(urf => urf.Email == email && urf.RefreshToken == refreshToken && urf.IsActive == true);
        }

        public async Task DeleteUserRefreshToken(string email, string refreshToken)
        {
            var urf = await _dbContext.UserRefreshTokens.FirstOrDefaultAsync(urf => urf.Email == email && urf.RefreshToken == refreshToken);
            if (urf != null) { _dbContext.UserRefreshTokens.Remove(urf); }
        }

        #endregion


        #region Helper_Methods
        private static Expression<Func<User, bool>> EmailFilter(string email, long? userId = null)
        => userId is null ? user => user.Email == email : user => user.Email == email && user.Id != userId;

        #endregion
    }
}
