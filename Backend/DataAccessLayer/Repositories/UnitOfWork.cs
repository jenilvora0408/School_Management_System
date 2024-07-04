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
    private IClassRepository _classRepository;
    private IStudentRepository _studentRepository;
    private ISubjectRepository _subjectRepository;
    private IMediumRepository _mediumRepository;

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

    public IClassRepository ClassRepository
    {
        get
        {
            return _classRepository ??= new ClassRepository(_dbContext);
        }
    }

    public IStudentRepository StudentRepository
    {
        get
        {
            return _studentRepository ??= new StudentRepository(_dbContext);
        }
    }

    public ISubjectRepository SubjectRepository
    {
        get
        {
            return _subjectRepository ??= new SubjectRepository(_dbContext);
        }
    }

    public IMediumRepository MediumRepository
    {
        get
        {
            return _mediumRepository ??= new MediumRepository(_dbContext);
        }
    }

    #endregion
}
