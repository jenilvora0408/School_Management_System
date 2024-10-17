namespace DataAccessLayer.Interface;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken cancellationToken = default);

    public IAdmitRequestRepository AdmitRequestRepository { get; }

    public IUserRepository UserRepository { get; }

    public IGenderRepository GenderRepository { get; }

    public IBloodGroupRepository BloodGroupRepository { get; }

    public IUserRoleRepository UserRoleRepository { get; }

    public IClassRepository ClassRepository { get; }

    public IStudentRepository StudentRepository { get; }

    public IMediumRepository MediumRepository { get; }

    public ILeaveRepository LeaveRepository { get; }

    public IClassSubjectRepository ClassSubjectRepository { get; }

    public ISubjectRepository SubjectRepository { get; }

    public IContactTypeRepository ContactTypeRepository { get; }

    public IContactPrincipalRepository ContactPrincipalRepository { get; }

    public IDocumentRepository DocumentRepository { get; }
}
