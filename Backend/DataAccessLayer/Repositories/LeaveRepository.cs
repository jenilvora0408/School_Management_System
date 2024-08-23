using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class LeaveRepository(AppDbContext context) : BaseRepository<Leave>(context), ILeaveRepository
{
}
