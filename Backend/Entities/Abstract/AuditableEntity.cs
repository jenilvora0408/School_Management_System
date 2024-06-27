using Common.Utils;
using Entities.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Abstract;

public class AuditableEntity<T> : IdentityEntity<T>
{
    public DateTime CreatedOn { get; set; } = DateUtil.UtcNow;

    public DateTime? UpdatedOn { get; set; } = DateUtil.UtcNow;

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    [ForeignKey(nameof(CreatedBy))]
    public virtual User? CreatedByUser { get; set; }

    [ForeignKey(nameof(UpdatedBy))]
    public virtual User? UpdatedByUser { get; set; }
}

