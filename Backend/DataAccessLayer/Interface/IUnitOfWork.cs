namespace DataAccessLayer.Interface;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken cancellationToken = default);

    public IAdmitRequestRepository AdmitRequestRepository { get; }

    public IUserRepository UserRepository { get; }

    public IAdmitRequestApprovalRepository AdmitRequestApprovalRepository { get; }

    public IGenderRepository GenderRepository { get; }

    public IBloodGroupRepository BloodGroupRepository { get; }

    public IUserRoleRepository UserRoleRepository { get; }

}
