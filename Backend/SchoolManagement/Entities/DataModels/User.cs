using Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels
{
    public class User : AuditableEntity<long>
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

        [StringLength(150)]
        [Column("password", TypeName = "varchar")]
        public string Password { get; set; } = null!;

        [StringLength(50)]
        [Column("headline", TypeName = "varchar")]
        public string? Headline { get; set; }

        [StringLength(13)]
        [Column("phone_number", TypeName = "varchar")]
        public string PhoneNumber { get; set; } = null!;

        [StringLength(1000)]
        [Column("address", TypeName = "varchar")]
        public string Address { get; set; } = null!;

        [Column("dob")]
        public DateTime DateOfBirth { get; set; }

        [Column("role")]
        public byte Role { get; set; }

        [Column("principal_id")]
        public long? PrincipalId { get; set; }

        [Column("lab_instructor_id")]
        public long? LabInstructorId { get; set; }

        [Column("teacher_id")]
        public long? TeacherId { get; set; }

        [Column("gender")]
        public byte Gender { get; set; }

        [StringLength(512)]
        [Column("avatar", TypeName = "varchar")]
        public string Avatar { get; set; } = null!;

        [MaxLength(7)]
        [Column("otp", TypeName = "varchar")]
        public string? OTP { get; set; }

        [Column("expiry_time")]
        public DateTime? ExpiryTime { get; set; }

        [Column("blood_group")]
        public byte BloodGroup { get; set; }

        [Column("deleted_on")]
        public DateTime? DeletedOn { get; set; }

        [Column("deleted_by")]
        public long? DeletedBy { get; set; }

        [Column("suspended_on")]
        public DateTime? SuspendedOn { get; set; }

        [Column("suspended_by")]
        public long? SuspendedBy { get; set; }

        [Column("suspended_duration")]
        public int? SuspendedDuration { get; set; }

        [Column("is_user_active")]
        public bool IsUserActive { get; set; }

        [Column("is_user_deleted")]
        public bool IsUserDeleted { get; set; }


        #region Foreign_Keys

        [ForeignKey(nameof(Role))]
        public virtual UserRole UserRoles { get; set; } = null!;

        [ForeignKey(nameof(PrincipalId))]
        public virtual User? Principal { get; set; }

        [ForeignKey(nameof(LabInstructorId))]
        public virtual User? LabUsers { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public virtual User? Teachers { get; set; }

        [ForeignKey(nameof(Gender))]
        public virtual Gender Genders { get; set; } = null!;

        [ForeignKey(nameof(BloodGroup))]
        public virtual BloodGroup BloodGroups { get; set; } = null!;

        [ForeignKey(nameof(DeletedBy))]
        public virtual User? DeletedByUser { get; set; }

        [ForeignKey(nameof(SuspendedBy))]
        public virtual User? SuspendedByUser { get; set; }

        #endregion
    }
}
