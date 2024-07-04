using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class MediumRepository : BaseRepository<Medium>, IMediumRepository
{
    public MediumRepository(AppDbContext context) : base(context)
    {

    }
}
