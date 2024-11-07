using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class AssignmentQuestionRepository(AppDbContext context) : BaseRepository<AssignmentQuestion>(context), IAssignmentQuestionRepository
{

}
