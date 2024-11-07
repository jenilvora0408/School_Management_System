using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.DataModels;

public class AssignmentQuestion : IdentityEntity<int>
{
    public int AssignmentId { get; set; }

    public string Question { get; set; } = null!;

    public string TypeOfQuestion { get; set; } = null!;

    public int? MarksOfQuestion { get; set; }

    public bool IsDeleted { get; set; }

    #region Foreign_Keys

    [ForeignKey(nameof(AssignmentId))]
    public virtual Assignment Assignments { get; set; } = null!;

    #endregion Foreign_Keys
}
