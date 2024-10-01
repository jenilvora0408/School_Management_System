using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class ContactPrincipalRepository(AppDbContext context) : BaseRepository<ContactPrincipal>(context), IContactPrincipalRepository
{
}
