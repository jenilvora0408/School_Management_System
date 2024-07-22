using Entities.DataModels;
using Entities.DTOs;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class GenderMappingProfile
{
    public static List<GenericEntityResponseDTO> ToGenericEntityResponseDTOs(this IEnumerable<Gender> genders)
    {
        return genders.Select(gender => new GenericEntityResponseDTO()
        {
            Id = gender.Id,
            Title = gender.Title
        }).ToList();
    }
}
