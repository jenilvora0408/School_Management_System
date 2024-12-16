using Entities.DTOs;

namespace BusinessAccessLayer.Interface;

public interface IStudentService
{
    Task<PageListResponseDTO<StudentsSubjectListDTO>> GetStudentsSubjectsList(UserPageListRequestDTO userPageListRequestDTO);
}
