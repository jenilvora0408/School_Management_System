using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class ClassSubjectRepository(AppDbContext context) : BaseRepository<ClassSubject>(context), IClassSubjectRepository
{
}