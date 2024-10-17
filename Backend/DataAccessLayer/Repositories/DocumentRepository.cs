using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class DocumentRepository(AppDbContext context): BaseRepository<Document>(context), IDocumentRepository
{
}
