using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class AdmitRequestRepository : BaseRepository<AdmitRequest>, IAdmitRequestRepository
{
    public AdmitRequestRepository(AppDbContext context) : base(context)
    {

    }
}
