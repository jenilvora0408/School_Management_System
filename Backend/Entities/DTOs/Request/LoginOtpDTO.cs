using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public class LoginOtpDTO
{
    [EmailAddress]
    public string Email { get; set; } = null!;

    public string Otp { get; set; } = null!;
}
