using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public class EmailRequestDTO
{
    [EmailAddress]
    public string Email { get; set; } = null!;
}
