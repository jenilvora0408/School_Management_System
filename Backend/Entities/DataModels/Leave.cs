using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.DataModels
{
    public class Leave : AuditableEntity<long>
    {
        public long UserId { get; set; }

        public long ApprovalFromUserId { get; set; }

        public string ReasonForLeave { get; set; } = null!;

        public byte ApprovalStatus { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LeaveStartType { get; set; } = null!;

        public string LeaveEndType { get; set; } = null!;

        public string LeaveDuration { get; set; } = null!;

        public string LeaveType { get; set; } = null!;

        public bool? AvailabilityOnPhone { get; set; }

        public string? AlternatePhoneNumber { get; set; }

        #region Foreign_Keys

        [ForeignKey(nameof(UserId))]
        public virtual User? Users { get; set; }

        [ForeignKey(nameof(ApprovalFromUserId))]
        public virtual User? ApprovalFromUsers { get; set; }

        #endregion Foreign_Keys
    }
}