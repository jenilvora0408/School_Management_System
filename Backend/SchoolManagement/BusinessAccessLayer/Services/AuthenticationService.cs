using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Common.Utils;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs.Common;
using Entities.DTOs.Request;

namespace BusinessAccessLayer.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Constructor

        private readonly IMailService _mailService;
        public readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(IMailService mailService, IUnitOfWork unitOfWork) 
        {
            _mailService = mailService;
            _unitOfWork = unitOfWork;
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
                Body = "This is Otp for School Management. <br>" + user.OTP + " <br> it will valid for 10 minutes only.",
            };
            await _mailService.SendMailAsync(mailDto);
        }

        #endregion
    }
}
