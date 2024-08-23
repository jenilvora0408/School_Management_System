using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.DataModels;

public class ClassSubject : AuditableEntity<int>
{
    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    #region Foreign_Keys

    [ForeignKey(nameof(ClassId))]
    public virtual Class Classes { get; set; } = null!;

    [ForeignKey(nameof(SubjectId))]
    public virtual Subject Subjects { get; set; } = null!;

    #endregion Foreign_Keys
}
