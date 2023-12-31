﻿namespace DataAccessLayer.Interface
{
    public interface IUnitOfWork
    {
        Task SaveAsync(CancellationToken cancellationToken = default);

        public IAdmitRequestRepository AdmitRequestRepository { get; }

        public IAuthenticationRepository AuthenticationRepository { get; }

        public IAdmitRequestApprovalRepository AdmitRequestApprovalRepository { get; }
    }
}
