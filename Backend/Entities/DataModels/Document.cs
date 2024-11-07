using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.DataModels;

public class Document : IdentityEntity<long>
{
    public string DocumentContent { get; set; } = null!;

    public string UseDocumentFor { get; set; } = null!;

    public int? ContactPrincipalId { get; set; }

    public int? CourseId { get; set; }

    #region Foreign_Keys

    [ForeignKey(nameof(ContactPrincipalId))]
    public virtual ContactPrincipal ContactPrincipals { get; set; } = null!;

    [ForeignKey(nameof(CourseId))]
    public virtual Course Courses { get; set; } = null!;

    #endregion Foreign_Keys
}
