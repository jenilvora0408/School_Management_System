using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class ContactTypeRepository(AppDbContext context) : BaseRepository<ContactType>(context), IContactTypeRepository
{
}