using Entities.DataModels;
using Entities.DTOs;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class ClassSubjectMappingProfile
{
    public static List<SubjectsListResponseDTO> ToClassSubjectListResponseDTOs(this List<ClassSubject> classSubjects)
    {
        return classSubjects.Select(cs => new SubjectsListResponseDTO()
        {
            SubjectId = cs.SubjectId,
            SubjectName = cs.Subjects.SubjectName,
            SubjectTeacherId = cs.Subjects.SubjectTeacherId,
            SubjectTeacherName = cs.Subjects.SubjectTeacher?.FirstName + ' ' + cs.Subjects.SubjectTeacher?.LastName,
            SubjectCode = cs.Subjects.SubjectCode
        }).ToList();
    }
}
