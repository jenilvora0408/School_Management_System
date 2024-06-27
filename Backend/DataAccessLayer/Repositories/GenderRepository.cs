using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class GenderRepository : BaseRepository<Gender>, IGenderRepository
{
    public GenderRepository(AppDbContext context) : base(context)
    {

    }
}
