using Common.Constants;
using Common.Validators;

namespace Entities.DTOs.Request
{
    public class LoginOtpDTO
    {
        [StringValidation(ErrorMessage = ValidationConstants.INVALID_EMAIL)]
        public string Email { get; set; } = null!;

        [StringValidation(ErrorMessage = ValidationConstants.INVALID_OTP)]
        public string Otp { get; set; } = null!;
    }
}
