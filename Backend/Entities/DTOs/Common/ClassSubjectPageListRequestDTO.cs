namespace Entities.DTOs;

public class ClassSubjectPageListRequestDTO: PageListRequestDTO
{
    public int ClassId { get; set; }

    public int SubjectId { get; set; }
}
