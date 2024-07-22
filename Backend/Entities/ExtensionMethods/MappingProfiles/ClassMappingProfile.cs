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
}
