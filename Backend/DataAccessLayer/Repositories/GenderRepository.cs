using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class GenderRepository(AppDbContext context) : BaseRepository<Gender>(context), IGenderRepository
{
}
