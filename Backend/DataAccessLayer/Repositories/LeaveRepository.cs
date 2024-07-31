using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class LeaveRepository : BaseRepository<Leave>, ILeaveRepository
{
    public LeaveRepository(AppDbContext context) : base(context)
    {

    }
}
