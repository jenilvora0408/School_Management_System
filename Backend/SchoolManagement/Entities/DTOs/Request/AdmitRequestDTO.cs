using Common.Constants;
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
        [Range(1, 3)]
        public byte Gender { get; set; }
            
        public IFormFile Avatar { get; set; } = null!;

        [Required]
        [Range(1, 8)]
        public byte BloodGroup { get; set; }
    }
}
