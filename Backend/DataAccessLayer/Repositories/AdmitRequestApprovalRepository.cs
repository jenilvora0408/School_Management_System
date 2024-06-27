using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories
{
    public class AdmitRequestApprovalRepository : BaseRepository<AdmitRequestApproval>, IAdmitRequestApprovalRepository
    {
        public AdmitRequestApprovalRepository(AppDbContext context) : base(context)
        {

        }
    }
}
