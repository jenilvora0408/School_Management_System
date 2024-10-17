using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public class ContactPrincipalDTO
{
    [Required]
    public long UserId { get; set; }

    [Required]
    public string Subject { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;
    
    public DateTime? RequestDate { get; set; }

    public byte Type { get; set; }

    public string? RelatableEvidence { get; set; }

    public string[]? DocumentContent { get; set; }
}
