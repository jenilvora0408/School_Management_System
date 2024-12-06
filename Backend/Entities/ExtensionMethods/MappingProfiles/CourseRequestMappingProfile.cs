using Entities.DataModels;
using Entities.DTOs;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class CourseRequestMappingProfile
{
    public static List<Course> ToCourseList(this IEnumerable<AddChaptersDTO> chaptersDTO, int classSubjectId)
    {
        return chaptersDTO.Select((chapterDTO, index) =>
        {
            return new Course
            {
                Id = 0,
                ChapterName = chapterDTO.ChapterName,
                ClassSubjectId = classSubjectId,
                ChapterSerialNumber = chapterDTO.ChapterSerialNumber,
                ProbableDurationToTeach = chapterDTO.ProbableDurationToTeach,
                ProbableWeightageInExam = chapterDTO.ProbableWeightageInExam > 0
                    ? chapterDTO.ProbableWeightageInExam : null,
                IsOptionalToTeach = chapterDTO.IsOptionalToTeach,
                LearningObjectives = chapterDTO.LearningObjectives
            };
        }).ToList();
    }


    public static List<GetCoursesForClassSubjectDTO> ToGetAllCourseForClassSubjects(this List<Course> courses)
    {
        return courses.Select(cs => new GetCoursesForClassSubjectDTO()
        {
            CourseId = cs.Id,
            ChapterName = cs.ChapterName,
            ProbableDurationToTeach = cs.ProbableDurationToTeach,
            ProbableWeightageInExam = cs.ProbableWeightageInExam,
            IsOptionalToTeach = cs.IsOptionalToTeach,
            LearningObjectives = cs.LearningObjectives,
            ChapterSerialNumber = cs.ChapterSerialNumber,
            ClassId = cs.ClassSubjects.ClassId,
            SubjectId = cs.ClassSubjects.SubjectId,
            ClassName = cs.ClassSubjects.Classes.ClassName,
            SubjectName = cs.ClassSubjects.Subjects.SubjectName
        }).ToList();
    }

    public static List<ClassSubjectChaptersPageListResponseDTO> ToGetChaptersForClassSubject(this List<Course> courses)
    {
        return courses.Select(cs => cs.ToGetChaptersData()).ToList();
    }

    public static ClassSubjectChaptersPageListResponseDTO ToGetChaptersData(this Course course)
    {
        return new ClassSubjectChaptersPageListResponseDTO
        {
            ChapterId = course.Id,
            ClassSubjectId = course.ClassSubjectId,
            ChapterName = course.ChapterName,
            ProbableDurationToTeach = course.ProbableDurationToTeach,
            ProbableWeightageInExam = course.ProbableWeightageInExam,
            IsOptionalToTeach = course.IsOptionalToTeach,
            ChapterSerialNumber = course.ChapterSerialNumber
        };
    }

}

