using System.Net;
using BusinessAccessLayer.Interface;
using Common.Exceptions;
using Common.Utils;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs;
using Entities.DTOs.Common;
using Entities.ExtensionMethods.MappingProfiles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using static Common.Constants.MessageConstants;

namespace BusinessAccessLayer.Services;

public class UserService : BaseService<User>, IUserService
{
    #region Constructor

    private readonly IMailService _mailService;
    public readonly IUnitOfWork _unitOfWork;
    private readonly ICommonService _commonService;
    private readonly IHostingEnvironment _environment;
    private readonly IJwtManagerService _jwtManagerService;

    public UserService(IUnitOfWork unitOfWork, IMailService mailService, ICommonService commonService, IHostingEnvironment environment, IJwtManagerService jwtManagerService) : base(unitOfWork.UserRepository, unitOfWork)
    {
        _mailService = mailService;
        _unitOfWork = unitOfWork;
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
            throw new CustomException((int)HttpStatusCode.Forbidden, ValidationConstants.ACCESS_ALREADY_PROVIDED);

        AdmitRequest? admitRequest = await _unitOfWork.AdmitRequestRepository.GetFirstOrDefaultAsync(request => request.Email == admitRequestDTO.Email);

        if (admitRequest != null)
        {
            AdmitRequest? admitRequestApproval = await _unitOfWork.AdmitRequestRepository.GetFirstOrDefaultAsync(approval => approval.Id == admitRequest.Id && approval.ApprovalStatus == 5);

            if (admitRequestApproval != null)
                throw new CustomException((int)HttpStatusCode.Forbidden, ValidationConstants.ACCESS_BLOCKED);

            throw new CustomException((int)HttpStatusCode.Forbidden, ValidationConstants.ADMIT_REQUEST_ALREADY_EXISTS);
        }

        AdmitRequest createRequest = AdmitRequestMappingProfile.ToAdmitRequest(admitRequestDTO);
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
            string otp = await GenerateOtp(user);

            //sent otp in mail
            MailDTO mailDto = new()
            {
                ToEmail = user.Email,
                Subject = EmailConstants.OTP_SUBJECT,
                Body = MailBodyUtil.SendOtpForAuthenticationBody(otp, user.FirstName + " " + user.LastName, _environment.WebRootPath)
            };
            await _mailService.SendMailAsync(mailDto);
        }
    }

    public async Task<TokensDTO> VerifyOtp(LoginOtpDTO otpData)
    {
        User? user = await _commonService.GetUserByEmail(otpData.Email) ?? throw new ModelValidationException(ValidationConstants.DEFAULT_MODELSTATE);

        if (user.OTP != otpData.Otp || user.ExpiryTime < DateTime.UtcNow) throw new ModelValidationException(ValidationConstants.INVALID_OTP);

        user.ToVerifyOtp();

        await _unitOfWork.UserRepository.UpdateAsync(user);
        await _unitOfWork.SaveAsync();

        TokensDTO token = _jwtManagerService.GenerateToken(user) ?? throw new ModelValidationException(ValidationConstants.INVALID_OTP);

        return token;
    }

    public async Task ForgetPassword(string email)
    {
        User? user = await _commonService.GetUserByEmail(email) ?? throw new ModelValidationException(ErrorMessage.USER_NOT_FOUND);

        string otp = await GenerateOtp(user);

        MailDTO mailDto = new()
        {
            ToEmail = user.Email,
            Subject = EmailConstants.OTP_SUBJECT,
            Body = MailBodyUtil.SendOtpForResetPasswordBody(otp, user.FirstName + " " + user.LastName, _environment.WebRootPath)
        };
        await _mailService.SendMailAsync(mailDto);
    }

    public async Task ResetPassword(LoginCredentialsDTO loginCredentialsDTO)
    {
        User? user = await _commonService.GetUserByEmail(loginCredentialsDTO.Email) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.USER_NOT_FOUND);

        string password = PasswordUtil.HashPassword(loginCredentialsDTO.Password);
        user.ToSetPassword(password);

        await UpdateAsync(user);
        await _unitOfWork.SaveAsync();
    }

    #endregion Http_Methods

    #region Helper_Methods

    public async Task<string> GenerateOtp(User user)
    {
        Random generator = new Random();
        string otp = generator.Next(100000, 999999).ToString();
        DateTime expiryTime = DateTime.UtcNow.AddMinutes(10);

        user.ToGenerateOtp(otp, expiryTime);

        await UpdateAsync(user);
        await _unitOfWork.SaveAsync();

        return otp;
    }


    #endregion Helper_Methods
}
