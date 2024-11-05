using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using Entities.DataModels;

namespace DataAccessLayer.Repositories;

public class CourseRepository(AppDbContext context) : BaseRepository<Course>(context), ICourseRepository
{

}
