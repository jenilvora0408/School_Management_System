using System.Net;
using AutoMapper;
using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Common.Utils;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs;
using Entities.DTOs.Common;
using static Common.Constants.MessageConstants;

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

    public async Task<string> Login(LoginCredentialsDTO userCredential)
    {
        User? user = await _commonService.GetUserByEmail(userCredential.Email);
        if (user == null || !PasswordUtil.VerifyPassword(userCredential.Password, user.Password)) throw new ModelValidationException(ValidationConstants.INVALID_LOGIN_CREDENTIAL);

        await SendOtp(user.Email);
        return user.FirstName;
    }

    public async Task SendOtp(string email)
    {
        User? user = await _commonService.GetUserByEmail(email);
        if (user != null)
        {
            //generate a random number of six digit
            Random generator = new Random();
            user.OTP = generator.Next(100000, 999999).ToString();
            user.ExpiryTime = DateTime.UtcNow.AddMinutes(10);
            await UpdateAsync(user);
            await _unitOfWork.SaveAsync();

            //sent otp in mail
            MailDTO mailDto = new()
            {
                ToEmail = user.Email,
                Subject = EmailConstants.OTP_SUBJECT,
                Body = "This Otp is for School Management. <br>" + user.OTP + " <br> It will be valid for 10 minutes only.",
            };
            await _mailService.SendMailAsync(mailDto);
        }
    }

    #endregion Http_Methods
}
