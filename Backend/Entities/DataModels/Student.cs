using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.DataModels
{
    public class Student : AuditableEntity<int>
    {
        public string StudentName { get; set; } = null!;

        public int ClassId { get; set; }

        public byte MediumId { get; set; }

        #region Foreign_Keys

        [ForeignKey(nameof(ClassId))]
        public virtual Class Classes { get; set; } = null!;

        [ForeignKey(nameof(MediumId))]
        public virtual Medium? Mediums { get; set; } = null!;

        #endregion Foreign_Keys
    }
}