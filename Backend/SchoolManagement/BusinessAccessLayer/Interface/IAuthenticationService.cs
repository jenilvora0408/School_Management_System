using Entities.DataModels;
using Entities.DTOs.Common;
using Entities.DTOs.Request;

namespace BusinessAccessLayer.Interface
{
    public interface IAuthenticationService 
    {
        Task<string> Login(LoginCredentialsDTO userCredential);

        Task SendOtp(string email);

        Task<TokensDTO> VerifyOtp(LoginOtpDTO otpData, bool rememberMe);

        Task ForgotPassword(string email);

        Task ResetPassword(string password, string token);
    }
}
