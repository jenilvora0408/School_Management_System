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
        Id = classRequestDTO.ClassId ?? 0,
        ClassName = classRequestDTO.ClassName,
        ClassStrength = classRequestDTO.ClassStrength,
        ClassTeacherId = classRequestDTO.ClassTeacherId
    };
}
