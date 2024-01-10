using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Response
{
    public class ApproveAdmitResponseDTO
    {
        public long AdmitRequestId { get; set; }

        public byte ApprovalStatus { get; set; }

        public string? Comment { get; set; }

        public long? ApprovedBy { get; set; }

        public long? DeclinedBy { get; set; }
    }
}
