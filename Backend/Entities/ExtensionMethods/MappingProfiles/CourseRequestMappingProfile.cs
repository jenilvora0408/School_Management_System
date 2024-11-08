using Entities.DataModels;
using Entities.DTOs;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class CourseRequestMappingProfile
{
    public static List<Course> ToCourseList(this List<AddChaptersDTO> chaptersDTO, int classSubjectId, List<Course> existingCourses)
    {
        return chaptersDTO.Select((chapterDTO, index) =>
        {
            Course? existingCourse = existingCourses.FirstOrDefault(course => course.Id == chapterDTO.CourseId);
            
            if (existingCourse != null)
            {
                existingCourse.ChapterName = chapterDTO.ChapterName;
                existingCourse.ProbableDurationToTeach = chapterDTO.ProbableDurationToTeach;
                existingCourse.ProbableWeightageInExam = chapterDTO.ProbableWeightageInExam;
                existingCourse.IsOptionalToTeach = chapterDTO.IsOptionalToTeach;
                existingCourse.LearningObjectives = chapterDTO.LearningObjectives;
                existingCourse.ClassSubjectId = classSubjectId;
                existingCourse.ChapterSerialNumber = chapterDTO.ChapterSerialNumber;

                return existingCourse;
            }
            else
            {
                return new Course
                {
                    ChapterName = chapterDTO.ChapterName,
                    ClassSubjectId = classSubjectId,
                    ChapterSerialNumber = chapterDTO.ChapterSerialNumber,
                    ProbableDurationToTeach = chapterDTO.ProbableDurationToTeach,
                    ProbableWeightageInExam = chapterDTO.ProbableWeightageInExam,
                    IsOptionalToTeach = chapterDTO.IsOptionalToTeach,
                    LearningObjectives = chapterDTO.LearningObjectives
                };
            }
        }).ToList();
    }
}

