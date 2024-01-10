using AutoMapper;
using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs.Response;

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

        public async Task<string> ApproveAdmitRequest(ApproveAdmitResponseDTO approveAdmitResponseDTO, long userId)
        {
            AdmitRequest? admitRequest = await _unitOfWork.AdmitRequestRepository.GetFirstOrDefaultAsync(x => x.Id == approveAdmitResponseDTO.AdmitRequestId);

            if (admitRequest == null)
                throw new ResourceNotFoundException(ValidationConstants.RECORD_NOT_FOUND);

            if (approveAdmitResponseDTO.ApprovalStatus == 2)
            {
                _mapper.Map<User>(admitRequest);
                approveAdmitResponseDTO.ApprovedBy = userId;
                return MessageConstants.ADMIT_REQUEST_APPROVED;
            }
            
            else
                approveAdmitResponseDTO.DeclinedBy = userId;

            _mapper.Map<AdmitRequestApproval>(approveAdmitResponseDTO);
            return MessageConstants.ADMIT_REQUEST_DECLINED;
        }

        #endregion
    }
}
