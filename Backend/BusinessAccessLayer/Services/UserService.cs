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
using Microsoft.AspNetCore.Hosting;
using static Common.Constants.MessageConstants;

namespace BusinessAccessLayer.Services;

public class UserService : BaseService<User>, IUserService
{
    #region Constructor

    private readonly IMailService _mailService;
    public readonly IUnitOfWork _unitOfWork;
    private readonly ICommonService _commonService;
    private readonly IMapper _mapper;
    private readonly IHostingEnvironment _environment;
    private readonly IJwtManagerService _jwtManagerService;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, IMailService mailService, ICommonService commonService, IHostingEnvironment environment, IJwtManagerService jwtManagerService) : base(unitOfWork.UserRepository, unitOfWork)
    {
        _mailService = mailService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _commonService = commonService;
        _environment = environment;
        _jwtManagerService = jwtManagerService;
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
                Body = MailBodyUtil.SendOtpForAuthenticationBody(user.OTP, user.FirstName + " " + user.LastName, _environment.WebRootPath)
            };
            await _mailService.SendMailAsync(mailDto);
        }
    }

    public async Task<TokensDTO> VerifyOtp(LoginOtpDTO otpData)
    {
        User? user = await _commonService.GetUserByEmail(otpData.Email) ?? throw new ModelValidationException(ValidationConstants.DEFAULT_MODELSTATE);

        if (user.OTP != otpData.Otp || user.ExpiryTime < DateTime.UtcNow) throw new ModelValidationException(ValidationConstants.INVALID_OTP);

        user.OTP = null;
        user.ExpiryTime = null;

        await _unitOfWork.UserRepository.UpdateAsync(user);
        await _unitOfWork.SaveAsync();

        TokensDTO token = _jwtManagerService.GenerateToken(user) ?? throw new ModelValidationException(ValidationConstants.INVALID_OTP);

        return token;
    }

    #endregion Http_Methods
}
