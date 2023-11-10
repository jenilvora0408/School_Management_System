using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Request
{
    public class LoginCredentialsDTO
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; } = false;
    }
}
