using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.DataModels;

public class Assignment : AuditableEntity<int>
{
    public long AssignmentPublisherId { get; set; }

    public string AssignmentTitle { get; set; } = null!;

    public string? AssignmentInstructions { get; set; }

    public DateTime Deadline { get; set; }

    public int? ClassSubjectId { get; set; }

    #region Foreign_Keys

    [ForeignKey(nameof(AssignmentPublisherId))]
    public virtual User AssignmentPublisher { get; set; } = null!;

    [ForeignKey(nameof(ClassSubjectId))]
    public virtual ClassSubject ClassSubjects { get; set; } = null!;

    #endregion Foreign_Keys
}
