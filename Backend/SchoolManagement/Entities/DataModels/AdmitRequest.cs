using Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels
{
    public class AdmitRequest : AuditableEntity<long>
    {
        [StringLength(18)]
        [Column("first_name", TypeName = "varchar")]
        public string FirstName { get; set; } = null!;

        [StringLength(18)]
        [Column("last_name", TypeName = "varchar")]
        public string LastName { get; set; } = null!;

        [StringLength(32)]
        [Column("email", TypeName = "varchar")]
        public string Email { get; set; } = null!;

        [StringLength(13)]
        [Column("phone_number", TypeName = "varchar")]
        public string PhoneNumber { get; set; } = null!;

        [StringLength(1000)]
        [Column("address", TypeName = "varchar")]
        public string Address { get; set; } = null!;

        [Column("dob")]
        public DateTime DateOfBirth { get; set; }

        [Column("gender")]
        public byte Gender { get; set; }

        [StringLength(512)]
        [Column("avatar", TypeName = "varchar")]
        public string Avatar { get; set; } = null!;

        [Column("blood_group")]
        public byte BloodGroup { get; set; }
    }
}
