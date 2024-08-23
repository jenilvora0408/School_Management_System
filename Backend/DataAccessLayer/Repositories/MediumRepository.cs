using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class MediumRepository(AppDbContext context) : BaseRepository<Medium>(context), IMediumRepository
{
}
