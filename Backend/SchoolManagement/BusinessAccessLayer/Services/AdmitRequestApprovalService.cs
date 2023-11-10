using AutoMapper;
using BusinessAccessLayer.Interface;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace BusinessAccessLayer.Services
{
    public class AdmitRequestApprovalService : GenericService<AdmitRequestApproval>, IAdmitRequestApprovalService
    {
        #region Constructor

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdmitRequestApprovalService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork.AdmitRequestApprovalRepository, unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #endregion


        #region Methods



        #endregion
    }
}
