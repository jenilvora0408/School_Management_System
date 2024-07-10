using Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Common.Enums.SystemEnum;

namespace Entities.DataModels;

public class User : AuditableEntity<long>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Headline { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public byte RoleId { get; set; }

    public long? PrincipalId { get; set; }

    public long? LabInstructorId { get; set; }

    public long? TeacherId { get; set; }

    public byte GenderId { get; set; }

    public string Avatar { get; set; } = null!;

    public string? OTP { get; set; }

    public DateTime? ExpiryTime { get; set; }

    public byte BloodGroupId { get; set; }

    public DateTime? DeletedOn { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? SuspendedOn { get; set; }

    public long? SuspendedBy { get; set; }

    public int? SuspendedDuration { get; set; }

    public bool IsUserActive { get; set; }

    public bool IsUserDeleted { get; set; }

    public bool? HasForgottenPassword { get; set; }

    public bool? IsEligibleForResetPassword { get; set; }


    #region Foreign_Keys

    [ForeignKey(nameof(RoleId))]
    public virtual UserRole UserRoles { get; set; } = null!;

    [ForeignKey(nameof(PrincipalId))]
    public virtual User? Principal { get; set; }

    [ForeignKey(nameof(LabInstructorId))]
    public virtual User? LabUsers { get; set; }

    [ForeignKey(nameof(TeacherId))]
    public virtual User? Teachers { get; set; }

    [ForeignKey(nameof(GenderId))]
    public virtual Gender Genders { get; set; } = null!;

    [ForeignKey(nameof(BloodGroupId))]
    public virtual BloodGroup BloodGroups { get; set; } = null!;

    [ForeignKey(nameof(DeletedBy))]
    public virtual User? DeletedByUser { get; set; }

    [ForeignKey(nameof(SuspendedBy))]
    public virtual User? SuspendedByUser { get; set; }

    #endregion
}

