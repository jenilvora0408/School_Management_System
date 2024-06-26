using Common.Constants;
using Common.Enums;
using Common.Validators;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Request
{
    public class AdmitRequestDTO
    {
        [StringValidation(ErrorMessage = ValidationConstants.INVALID_FIRST_NAME)]
        public string FirstName { get; set; } = null!;

        [StringValidation(ErrorMessage = ValidationConstants.INVALID_LAST_NAME)]
        public string LastName { get; set; } = null!;

        [StringValidation(ErrorMessage = ValidationConstants.INVALID_EMAIL)]
        public string Email { get; set; } = null!;

        [MinLength(10)]
        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public GenderType Gender { get; set; }

        public string Avatar { get; set; } = null!;

        [Required]
        public BloodGroupTypes BloodGroup { get; set; }

        [Required]
        public UserRoleType AdmitRequestRole { get; set; }
    }
}
