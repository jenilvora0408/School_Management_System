using Common.Constants;
using Common.Validators;

namespace Entities.DTOs.Request
{
    public class LoginOtpDTO
    {
        public string Email { get; set; } = null!;

        public string Otp { get; set; } = null!;
    }
}
