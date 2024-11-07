using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class AssignmentRepository(AppDbContext context) : BaseRepository<Assignment>(context), IAssignmentRepository
{

}
