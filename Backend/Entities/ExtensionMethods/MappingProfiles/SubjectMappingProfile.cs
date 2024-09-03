using Entities.DataModels;
using Entities.DTOs;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class SubjectMappingProfile
{
    public static IEnumerable<SubjectsListResponseDTO> ToGetAllSubjects(this IEnumerable<Subject> subjects)
    {
        return subjects.Select(subject => new SubjectsListResponseDTO()
        {
            SubjectId = subject.Id,
            SubjectName = subject.SubjectName,
            SubjectCode = subject.SubjectCode,
            SubjectTeacherName = subject.SubjectTeacher?.FirstName + ' ' + subject.SubjectTeacher?.LastName,
        }).ToList();
    }
}
