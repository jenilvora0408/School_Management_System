using DataAccessLayer.Data;
using DataAccessLayer.Interface;

namespace DataAccessLayer.Repositories;

public class UnitOfWork : IUnitOfWork
{
    #region Properties

    private IUserRepository _userRepository;
    private IAdmitRequestRepository _admitRequestRepository;
    private IAdmitRequestApprovalRepository _admitRequestApprovalRepository;
    private IGenderRepository _genderRepository;
    private IBloodGroupRepository _bloodGroupRepository;
    private IUserRoleRepository _userRoleRepository;

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

    public IBaseRepository<T> GetRepository<T>() where T : class
    {
        return new BaseRepository<T>(_dbContext);
    }

    public IAdmitRequestRepository AdmitRequestRepository
    {
        get
        {
            return _admitRequestRepository ??= new AdmitRequestRepository(_dbContext);
        }
    }

    public IUserRepository UserRepository
    {
        get
        {
            return _userRepository ??= new UserRepository(_dbContext);
        }
    }

    public IAdmitRequestApprovalRepository AdmitRequestApprovalRepository
    {
        get
        {
            return _admitRequestApprovalRepository ??= new AdmitRequestApprovalRepository(_dbContext);
        }
    }

    public IGenderRepository GenderRepository
    {
        get
        {
            return _genderRepository ??= new GenderRepository(_dbContext);
        }
    }

    public IBloodGroupRepository BloodGroupRepository
    {
        get
        {
            return _bloodGroupRepository ??= new BloodGroupRepository(_dbContext);
        }
    }

    public IUserRoleRepository UserRoleRepository
    {
        get
        {
            return _userRoleRepository ??= new UserRoleRepository(_dbContext);
        }
    }

    #endregion
}
