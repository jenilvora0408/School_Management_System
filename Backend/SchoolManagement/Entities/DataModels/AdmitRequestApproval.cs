using Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels
{
    public class AdmitRequestApproval : IdentityEntity<long>
    {
        [Column("admit_request_id")]
        public long AdmitRequestId { get; set; }

        [Column("approval_status")]
        public byte ApprovalStatus { get; set; }

        [StringLength(512)]
        [Column("comment", TypeName = "varchar")]
        public string? Comment { get; set; }

        [Column("approved_by")]
        public long ApprovedBy { get; set; }

        [Column("declined_by")]
        public long DeclinedBy { get; set; }


        #region Foreign_keys

        [ForeignKey(nameof(AdmitRequestId))]
        public virtual AdmitRequest AdmitRequests { get; set; } = null!;

        [ForeignKey(nameof(ApprovedBy))]
        public virtual User ApprovedByUser { get; set; } = null!;

        [ForeignKey(nameof(DeclinedBy))]
        public virtual User DeclinedByUser { get; set; } = null!;

        #endregion
    }
}
