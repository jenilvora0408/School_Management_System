using Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Common.Enums.SystemEnum;

namespace Entities.DataModels;

public class AdmitRequestApproval : IdentityEntity<long>
{
    public long AdmitRequestId { get; set; }

    public byte ApprovalStatus { get; set; }

    public string? Comment { get; set; }

    public long? ApprovedBy { get; set; }

    public long? DeclinedBy { get; set; }


    #region Foreign_keys

    [ForeignKey(nameof(AdmitRequestId))]
    public virtual AdmitRequest AdmitRequests { get; set; } = null!;

    [ForeignKey(nameof(ApprovedBy))]
    public virtual User? ApprovedByUser { get; set; }

    [ForeignKey(nameof(DeclinedBy))]
    public virtual User? DeclinedByUser { get; set; }

    #endregion
}

