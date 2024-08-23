using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.DataModels
{
    public class Subject : AuditableEntity<int>
    {
        public string SubjectName { get; set; } = null!;

        public string? SubjectCode { get; set; }

        public long? SubjectTeacherId { get; set; }

        #region Foreign_Keys

        [ForeignKey(nameof(SubjectTeacherId))]
        public virtual User? SubjectTeacher { get; set; }

        #endregion Foreign_Keys

        public virtual ICollection<ClassSubject> ClassSubjects { get; set; } = new HashSet<ClassSubject>();
    }
}