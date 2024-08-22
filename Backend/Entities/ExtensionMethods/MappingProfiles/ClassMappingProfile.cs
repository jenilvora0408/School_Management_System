using Entities.DataModels;
using Entities.DTOs;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class ClassMappingProfile
{
    public static List<GenericEntityResponseDTO> ToGenericEntityResponseDTOs(this IEnumerable<Class> classes)
    {
        return classes.Select(classes => new GenericEntityResponseDTO()
        {
            Id = (byte)classes.Id,
            Title = classes.ClassName
        }).ToList();
    }

    public static Class ToUpsertClasses(this ClassRequestDTO classRequestDTO) => new()
    {
        Id = classRequestDTO.ClassId,
        ClassName = classRequestDTO.ClassName,
        ClassStrength = classRequestDTO.ClassStrength,
        ClassTeacherId = classRequestDTO.ClassTeacherId
    };

    public static List<ClassesListResponseDTO> ToClassesListResponseDTOs(this List<Class> classes)
    {
        return classes.Select(classes => new ClassesListResponseDTO()
        {
            ClassId = classes.Id,
            ClassName = classes.ClassName,
            ClassTeacherName = classes.ClassTeachers?.FirstName + " " + classes.ClassTeachers?.LastName,
            ClassStrength = classes.ClassStrength,
            CreatedBy = classes.CreatedBy,
            UpdatedBy = classes.UpdatedBy
        }).ToList();
    }
}
