using System.ComponentModel.DataAnnotations;
using Common.Validators;
using Entities.DataModels;
using static Common.Constants.MessageConstants;

namespace Entities.DTOs;

public class AdmitRequestDTO
{
    [StringValidation(ErrorMessage = ValidationConstants.INVALID_FIRST_NAME)]
    public string FirstName { get; set; } = null!;

    [StringValidation(ErrorMessage = ValidationConstants.INVALID_LAST_NAME)]
    public string LastName { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; } = null!;

    [MinLength(10)]
    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    [Required]
    public byte GenderId { get; set; }

    public string? Avatar { get; set; }

    [Required]
    public byte BloodGroupId { get; set; }

    public int? ClassId { get; set; }

    public byte? MediumId { get; set; }

    [Required]
    public byte AdmitRequestRoleId { get; set; }


    public AdmitRequest ReturnAdmitRequest(AdmitRequestDTO admitRequestDTO)
    {
        return new AdmitRequest
        {
            FirstName = admitRequestDTO.FirstName,
            LastName = admitRequestDTO.LastName,
            Email = admitRequestDTO.Email,
            Address = admitRequestDTO.Address,
            PhoneNumber = admitRequestDTO.PhoneNumber,
            GenderId = admitRequestDTO.GenderId,
            Avatar = admitRequestDTO.Avatar,
            DateOfBirth = admitRequestDTO.DateOfBirth,
            BloodGroupId = admitRequestDTO.BloodGroupId,
            ClassId = admitRequestDTO.ClassId,
            MediumId = admitRequestDTO.MediumId,
            AdmitRequestRoleId = admitRequestDTO.AdmitRequestRoleId
        };
    }
}
