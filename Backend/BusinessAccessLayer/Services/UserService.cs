using System.Net;
using AutoMapper;
using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs;

namespace BusinessAccessLayer.Services;

public class UserService : BaseService<User>, IUserService
{
    #region Constructor

    private readonly IMailService _mailService;
    public readonly IUnitOfWork _unitOfWork;
    private readonly ICommonService _commonService;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, IMailService mailService, ICommonService commonService) : base(unitOfWork.UserRepository, unitOfWork)
    {
        _mailService = mailService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _commonService = commonService;
    }

    #endregion Constructor

    #region Http_Methods

    public async Task CreateAdmitRequest(AdmitRequestDTO admitRequestDTO, CancellationToken cancellationToken)
    {
        User? user = await _commonService.GetUserByEmail(admitRequestDTO.Email);
        if (user != null)
            throw new CustomException((int)HttpStatusCode.Forbidden, MessageConstants.ValidationConstants.ACCESS_ALREADY_PROVIDED);

        AdmitRequest? admitRequest = await _unitOfWork.AdmitRequestRepository.GetFirstOrDefaultAsync(request => request.Email == admitRequestDTO.Email);

        if (admitRequest != null)
        {
            AdmitRequestApproval? admitRequestApproval = await _unitOfWork.AdmitRequestApprovalRepository.GetFirstOrDefaultAsync(approval => approval.AdmitRequestId == admitRequest.Id && approval.ApprovalStatus == 5);

            if (admitRequestApproval != null)
                throw new CustomException((int)HttpStatusCode.Forbidden, MessageConstants.ValidationConstants.ACCESS_BLOCKED);

            throw new CustomException((int)HttpStatusCode.Forbidden, MessageConstants.ValidationConstants.ADMIT_REQUEST_ALREADY_EXISTS);
        }

        AdmitRequest createRequest = _mapper.Map<AdmitRequest>(admitRequestDTO);
        await _unitOfWork.AdmitRequestRepository.AddAsync(createRequest, cancellationToken);
        await _unitOfWork.SaveAsync();
    }

    #endregion Http_Methods
}
