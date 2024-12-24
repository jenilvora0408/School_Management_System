using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccessLayer.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    #region Properties

    private IUserRepository _userRepository;
    private IAdmitRequestRepository _admitRequestRepository;
    private IGenderRepository _genderRepository;
    private IBloodGroupRepository _bloodGroupRepository;
    private IUserRoleRepository _userRoleRepository;
    private IClassRepository _classRepository;
    private IStudentRepository _studentRepository;
    private ISubjectRepository _subjectRepository;
    private IMediumRepository _mediumRepository;
    private ILeaveRepository _leaveRepository;
    private IClassSubjectRepository _classSubjectRepository;
    private IContactTypeRepository _contactTypeRepository;
    private IContactPrincipalRepository _contactPrincipalRepository;
    private IDocumentRepository _documentRepository;
    private ICourseRepository _courseRepository;
    private IAssignmentRepository _assignmentRepository;
    private IAssignmentQuestionRepository _assignmentQuestionRepository;

    #endregion

    #region Constructor

    private readonly AppDbContext _dbContext = dbContext;
    private IDbContextTransaction _transaction;

    #endregion

    #region Methods

    public async Task SaveAsync(CancellationToken cancellationToken = default)
        => await _dbContext.SaveChangesAsync(cancellationToken);

    public IBaseRepository<T> GetRepository<T>() where T : class
    {
        return new BaseRepository<T>(_dbContext);
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
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

    public ILeaveRepository LeaveRepository
    {
        get
        {
            return _leaveRepository ??= new LeaveRepository(_dbContext);
        }
    }

    public IClassSubjectRepository ClassSubjectRepository
    {
        get
        {
            return _classSubjectRepository ??= new ClassSubjectRepository(_dbContext);
        }
    }

    public IContactTypeRepository ContactTypeRepository
    {
        get
        {
            return _contactTypeRepository ??= new ContactTypeRepository(_dbContext);
        }
    }

    public IContactPrincipalRepository ContactPrincipalRepository
    {
        get
        {
            return _contactPrincipalRepository ??= new ContactPrincipalRepository(_dbContext);
        }
    }

    public IDocumentRepository DocumentRepository
    {
        get
        {
            return _documentRepository ??= new DocumentRepository(_dbContext);
        }
    }

    public ICourseRepository CourseRepository
    {
        get
        {
            return _courseRepository ??= new CourseRepository(_dbContext);
        }
    }

    public IAssignmentRepository AssignmentRepository
    {
        get
        {
            return _assignmentRepository??= new AssignmentRepository(_dbContext);
        }
    }

    public IAssignmentQuestionRepository AssignmentQuestionRepository
    {
        get
        {
            return _assignmentQuestionRepository??= new AssignmentQuestionRepository(_dbContext);
        }
    }

    #endregion
}
