using System.Net;
using BusinessAccessLayer.Interface;
using Common.Constants;
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
using static Common.Enums.SystemEnum;

namespace BusinessAccessLayer.Services;

public class UserService(IUnitOfWork unitOfWork, IMailService mailService, ICommonService commonService, IHostingEnvironment environment, IJwtManagerService jwtManagerService) : BaseService<User>(unitOfWork.UserRepository, unitOfWork), IUserService
{
    #region Constructor

    private readonly IMailService _mailService = mailService;
    public readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICommonService _commonService = commonService;
    private readonly IHostingEnvironment _environment = environment;
    private readonly IJwtManagerService _jwtManagerService = jwtManagerService;

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
            AdmitRequest? admitRequestApproval = await _unitOfWork.AdmitRequestRepository.GetFirstOrDefaultAsync(approval => approval.Id == admitRequest.Id);

            if (admitRequestApproval != null && admitRequestApproval.ApprovalStatus == (int)StatusType.BLOCKED)
                throw new CustomException((int)HttpStatusCode.Forbidden, ValidationConstants.ACCESS_BLOCKED);

            if (admitRequestApproval != null && admitRequestApproval.ApprovalStatus == (int)StatusType.PENDING) throw new CustomException((int)HttpStatusCode.Forbidden, ValidationConstants.ADMIT_REQUEST_ALREADY_EXISTS);
        }

        AdmitRequest createRequest = AdmitRequestMappingProfile.ToAdmitRequest(admitRequestDTO);
        await _unitOfWork.AdmitRequestRepository.AddAsync(createRequest, cancellationToken);
        await _unitOfWork.SaveAsync();
    }

    public async Task<string> Login(LoginCredentialsDTO userCredential)
    {
        User? user = await _commonService.GetUserByEmail(userCredential.Email) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.USER_NOT_FOUND);

        if (!(user.IsUserDeleted == false && user.IsUserActive == true))
        {
            throw new CustomException(StatusCodes.Status403Forbidden, ErrorMessage.INVALID_USER);
        }

        if (!PasswordUtil.VerifyPassword(userCredential.Password, user.Password)) throw new ModelValidationException(ValidationConstants.INVALID_LOGIN_CREDENTIAL);

        await SendOtp(user.Email);
        return user.FirstName + ' ' + user.LastName;
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
        User? user = await _commonService.GetUserByEmail(otpData.Email) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.USER_NOT_FOUND);

        if (user.OTP != otpData.Otp || user.ExpiryTime < DateTime.UtcNow) throw new ModelValidationException(ValidationConstants.INVALID_OTP);

        user.ToVerifyOtp();

        await _unitOfWork.UserRepository.UpdateAsync(user);
        await _unitOfWork.SaveAsync();

        TokensDTO token = _jwtManagerService.GenerateToken(user) ?? throw new ModelValidationException(ValidationConstants.INVALID_OTP);

        return token;
    }

    public async Task ForgetPassword(string email)
    {
        User? user = await _commonService.GetUserByEmail(email) ?? throw new CustomException(StatusCodes.Status404NotFound, ErrorMessage.USER_NOT_FOUND);

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
        string otp = generator.Next(SystemConstants.OTP_GENERATE_MIN_VALUE, SystemConstants.OTP_GENERATE_MAX_VALUE).ToString();
        DateTime expiryTime = DateTime.UtcNow.AddMinutes(SystemConstants.OTP_EXPIRY_TIME);

        user.ToGenerateOtp(otp, expiryTime);

        await UpdateAsync(user);
        await _unitOfWork.SaveAsync();

        return otp;
    }


    #endregion Helper_Methods
}
