using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public class ContactPrincipalResponseDTO
{
    [Required]
    public int ContactPrincipalId { get; set; }

    [Required]
    public string ResponseMessage { get; set; } = null!;
}
