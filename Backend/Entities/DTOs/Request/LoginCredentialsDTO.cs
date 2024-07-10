using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public class LoginCredentialsDTO
{
    [EmailAddress]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
