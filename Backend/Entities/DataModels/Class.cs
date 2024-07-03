using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.DataModels
{
    public class Class : AuditableEntity<int>
    {
        public string ClassName { get; set; } = null!;

        public int? ClassStrength { get; set; }

        public long? ClassTeacherId { get; set; }

        #region Foreign_Keys

        [ForeignKey(nameof(ClassTeacherId))]
        public virtual User? ClassTeachers { get; set; }

        #endregion Foreign_Keys
    }
}