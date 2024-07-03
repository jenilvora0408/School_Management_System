using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels;

public class AdmitRequest : AuditableEntity<long>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public byte GenderId { get; set; }

    public string Avatar { get; set; } = null!;

    public byte BloodGroupId { get; set; }

    public byte AdmitRequestRoleId { get; set; }

    public int? ClassId { get; set; }

    public byte? MediumId { get; set; }

    #region Foreign_Keys

    [ForeignKey(nameof(GenderId))]
    public virtual Gender Genders { get; set; } = null!;

    [ForeignKey(nameof(BloodGroupId))]
    public virtual BloodGroup BloodGroups { get; set; } = null!;

    [ForeignKey(nameof(AdmitRequestRoleId))]
    public virtual UserRole AdmitRequestRoles { get; set; } = null!;

    [ForeignKey(nameof(ClassId))]
    public virtual Class? Classes { get; set; }

    [ForeignKey(nameof(MediumId))]
    public virtual Medium? Mediums { get; set; }

    #endregion
}

