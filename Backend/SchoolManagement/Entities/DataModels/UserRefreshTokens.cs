using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels
{
    public class UserRefreshTokens : AuditableEntity<long>
    {
        [Column("email")]
        public string Email { get; set; } = null!;

        [Column("refresh_token")]
        public string RefreshToken { get; set; } = null!;

        [Column("is_active")]
        public bool IsActive { get; set; } = true;
    }
}
