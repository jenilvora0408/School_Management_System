using Entities.DataModels;
using Entities.DTOs.Request;

namespace BusinessAccessLayer.Interface
{
    public interface IAuthenticationService 
    {
        Task<string> Login(LoginCredentialsDTO userCredential);

        Task SendOtp(string email);
    }
}
