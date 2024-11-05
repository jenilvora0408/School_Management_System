using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.DataModels;

public class Course : AuditableEntity<int>
{
    public int ChapterSerialNumber { get; set; }

    public string ChapterName { get; set; } = null!;

    public int ClassSubjectId { get; set; }

    public int? ProbableWeightageInExam { get; set; }

    public string? ProbableDurationToTeach { get; set; }

    public bool IsOptionalToTeach { get; set; }

    public string? LearningObjectives { get; set; }

    #region Foreign_Keys

    [ForeignKey(nameof(ClassSubjectId))]
    public virtual ClassSubject ClassSubjects { get; set; } = null!;

    #endregion Foreign_Keys
}
