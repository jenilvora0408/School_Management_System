namespace Entities.DTOs;

public class GetContactPrincipalListDTO
{
    public int ContactPrincipalId { get; set; }

    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? RequestDate { get; set; }

    public byte Type { get; set; }

    public string ContactTypeTitle { get; set; } = null!;

    public string? RelatableEvidence { get; set; }

    public bool IsResolved { get; set; }

    public string? ResponseMessage { get; set; }
}
