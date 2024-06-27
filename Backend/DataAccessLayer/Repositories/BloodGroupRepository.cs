using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class BloodGroupRepository : BaseRepository<BloodGroup>, IBloodGroupRepository
{
    public BloodGroupRepository(AppDbContext context) : base(context)
    {

    }
}
