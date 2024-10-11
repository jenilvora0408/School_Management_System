namespace Entities.DTOs;

public class GetContactPrincipalListDTO
{
    public int ContactPrincipalId { get; set; }

    public long UserId { get; set; }

    public string Subject { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? RequestDate { get; set; }

    public byte Type { get; set; }

    public string? RelatableEvidence { get; set; }

    public bool IsResolved { get; set; }

    public string? ResponseMessage { get; set; }
}
