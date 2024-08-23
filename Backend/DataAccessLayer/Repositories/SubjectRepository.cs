using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class SubjectRepository(AppDbContext context) : BaseRepository<Subject>(context), ISubjectRepository
{
}
