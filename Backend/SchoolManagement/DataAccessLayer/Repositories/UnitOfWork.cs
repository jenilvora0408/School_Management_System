using DataAccessLayer.Data;
using DataAccessLayer.Interface;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties

        private IAuthenticationRepository _authenticationRepository;
        private IAdmitRequestRepository _admitRequestRepository;
        private IAdmitRequestApprovalRepository _admitRequestApprovalRepository;

        #endregion


        #region Constructor

        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task SaveAsync(CancellationToken cancellationToken = default)
            => await _dbContext.SaveChangesAsync(cancellationToken);

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(_dbContext);
        }

        public IAdmitRequestRepository AdmitRequestRepository
        {
            get
            {
                return _admitRequestRepository ??= new AdmitRequestRepository(_dbContext);
            }
        }

        public IAuthenticationRepository AuthenticationRepository
        {
            get
            {
                return _authenticationRepository ??= new AuthenticationRepository(_dbContext);
            }
        }

        public IAdmitRequestApprovalRepository AdmitRequestApprovalRepository
        {
            get
            {
                return _admitRequestApprovalRepository ??= new AdmitRequestApprovalRepository(_dbContext);
            }
        }

        #endregion
    }
}
