using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories
{
    public class GenderRepository : GenericRepository<Gender>, IGenderRepository
    {
        public GenderRepository(AppDbContext context) : base(context)
        {

        }
    }
}
