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

    public static SubjectTeacherInfoDTO ToEmptySubjectTeacherInfoDTO(this User user)
    {
        return new SubjectTeacherInfoDTO
        {
            TeacherName = $"{user.FirstName} {user.LastName}",
            SubjectId = null,
            SubjectName = null,
            SubjectTeacherAssignedClasses = []
        };
    }

    public static SubjectTeacherInfoDTO ToSubjectTeacherInfoDTO(this Subject subject, User subjectTeacher, IEnumerable<Class> classes)
    {
        return new SubjectTeacherInfoDTO
        {
            TeacherName = $"{subjectTeacher.FirstName} {subjectTeacher.LastName}",
            SubjectId = subject.Id,
            SubjectName = subject.SubjectName,
            SubjectTeacherAssignedClasses = classes.Select(cls => cls.ToSubjectTeacherAssignedClassDTO()).ToList()
        };
    }

    public static SubjectTeacherAssignedClassDTO ToSubjectTeacherAssignedClassDTO(this Class cls)
    {
        return new SubjectTeacherAssignedClassDTO
        {
            ClassName = cls.ClassName,
            ClassTeacherId = cls.ClassTeacherId ?? 0,
            ClassTeacherName = cls.ClassTeachers != null ? $"{cls.ClassTeachers.FirstName} {cls.ClassTeachers.LastName}" : "N/A",
            ClassStrength = cls.ClassStrength ?? 0,
            ClassId = cls.Id
        };
    }

    public static List<StudentsSubjectListDTO> ToGetSubjectsListForStudents(List<Subject> subjects, int classId, string className)
    {
        return subjects.Select(leave => leave.ToGetStudentsSubjectData(classId, className)).ToList();
    }

    public static StudentsSubjectListDTO ToGetStudentsSubjectData(this Subject subject, int classId, string className)
    {
        return new StudentsSubjectListDTO
        {
            ClassId = classId,
            ClassName = className,
            SubjectId = subject.Id,
            SubjectName = subject.SubjectName,
            SubjectCode = subject.SubjectCode,
            SubjectTeacherId = subject.SubjectTeacherId,
            SubjectTeacherName = $"{subject.SubjectTeacher?.FirstName} {subject.SubjectTeacher?.LastName}"
        };
    }
}
