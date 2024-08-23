using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class BloodGroupRepository(AppDbContext context) : BaseRepository<BloodGroup>(context), IBloodGroupRepository
{
}
