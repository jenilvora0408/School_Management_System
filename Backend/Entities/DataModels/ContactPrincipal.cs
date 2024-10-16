using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.DataModels;

public class ContactPrincipal : IdentityEntity<int>
{
    public long UserId { get; set; }

    public string Subject { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime RequestDate { get; set; }

    public byte Type { get; set; }

    public bool IsResolved { get; set; }

    public string? ResponseMessage { get; set; }

    public string? RelatableEvidence { get; set; }

    #region Foreign_Keys

    [ForeignKey(nameof(Type))]
    public virtual ContactType ContactOfType { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User Users { get; set; } = null!;

    #endregion Foreign_Keys
}
