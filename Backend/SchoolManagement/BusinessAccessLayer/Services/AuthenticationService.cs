using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Common.Utils;
using DataAccessLayer.Interface;
using DataAccessLayer.Repositories;
using Entities.DataModels;
using Entities.DTOs.Common;
using Entities.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace BusinessAccessLayer.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Constructor

        private readonly IMailService _mailService;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IJwtManagerService _jwtManagerService;

        public AuthenticationService(IMailService mailService, IUnitOfWork unitOfWork, IJwtManagerService jwtManagerService) 
        {
            _mailService = mailService;
            _unitOfWork = unitOfWork;
            _jwtManagerService = jwtManagerService;
        }

        #endregion Constructor


        #region Methods

        public async Task<string> Login(LoginCredentialsDTO userCredential)
        {
            User user = await _unitOfWork.AuthenticationRepository.GetUserByEmail(userCredential.Email);
            if (user == null || !PasswordUtil.VerifyPassword(userCredential.Password, user.Password)) throw new ModelValidationException(ValidationConstants.INVALID_LOGIN_CREDENTIAL);

            await SendOtp(user.Email);
            return user.FirstName;
        }

        public async Task SendOtp(string email)
        {
            User user = await _unitOfWork.AuthenticationRepository.GetUserByEmail(email);
            //generate a random number of six digit
            Random generator = new Random();
            user.OTP = generator.Next(100000, 999999).ToString();
            user.ExpiryTime = DateTime.Now.AddMinutes(10);
            await _unitOfWork.AuthenticationRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();

            //sent otp in mail
            MailDTO mailDto = new()
            {
                ToEmail = user.Email,
                Subject = EmailConstants.OTP_SUBJECT,
                Body = "This is Otp for School Management. <br>" + user.OTP + " <br> it will be valid for 10 minutes only.",
            };
            await _mailService.SendMailAsync(mailDto);
        }

        public async Task<TokensDTO> VerifyOtp(LoginOtpDTO otpData, bool rememberMe)
        {
            User user = await _unitOfWork.AuthenticationRepository.GetUserByEmail(otpData.Email) ?? throw new ModelValidationException(ValidationConstants.DEFAULT_MODELSTATE);

            if (user.OTP != otpData.Otp || user.ExpiryTime < DateTime.Now) throw new ModelValidationException(ValidationConstants.INVALID_OTP);

            user.OTP = null;
            user.ExpiryTime = null;

            await _unitOfWork.AuthenticationRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();

            TokensDTO token = _jwtManagerService.GenerateToken(user) ?? throw new ModelValidationException(ValidationConstants.INVALID_OTP);
            if (rememberMe)
            {
                UserRefreshTokens userRefreshTokens = new()
                {
                    RefreshToken = token.RefreshToken,
                    Email = user.Email,
                };

                await _unitOfWork.AuthenticationRepository.AddUserRefreshToken(userRefreshTokens);
                await _unitOfWork.SaveAsync();
            }
            return token;
        }

        public async Task ResetPassword(string password, string token)
        {
            if (String.IsNullOrEmpty(token)) throw new ModelValidationException(MessageConstants.INVALID_TOKEN);
            DateTime dateTime = Convert.ToDateTime(DecodingMailToken(token).Split("&")[1]);
            if (dateTime < DateTime.UtcNow) throw new ModelValidationException(MessageConstants.TOKEN_EXPIRED);

            User user = await _unitOfWork.AuthenticationRepository.GetUserByEmail(DecodingMailToken(token).Split("&")[0]);
            user.Password = PasswordUtil.HashPassword(password);
            await _unitOfWork.AuthenticationRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task ForgotPassword(string email)
        {
            if (await _unitOfWork.AuthenticationRepository.GetUserByEmail(email) != null)
            {
                //sent otp in mail
                MailDTO mailDto = new()
                {
                    ToEmail = email,
                    Subject = EmailConstants.RESET_PASSWORD_SUBJECT,
                    Body = MailBodyUtil.SendResetPasswordLink("http://localhost:4200/reset-password?token=" + EncodingMailToken(email))
                };
                await _mailService.SendMailAsync(mailDto);
            }
        }

        #region HelperMethod

        public static string EncodingMailToken(string email) => System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(email + "&" + DateTime.UtcNow.AddMinutes(10)));
        public static string DecodingMailToken(string token) => System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(token));

        #endregion HelperMethod

        #endregion
    }
}