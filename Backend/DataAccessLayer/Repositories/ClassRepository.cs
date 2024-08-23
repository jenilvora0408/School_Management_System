using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class ClassRepository(AppDbContext context) : BaseRepository<Class>(context), IClassRepository
{
}
