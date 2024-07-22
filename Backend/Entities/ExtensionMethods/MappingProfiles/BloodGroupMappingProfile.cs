using Entities.DataModels;
using Entities.DTOs;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class BloodGroupMappingProfile
{
    public static List<GenericEntityResponseDTO> ToGenericEntityResponseDTOs(this IEnumerable<BloodGroup> bloodGroups)
    {
        return bloodGroups.Select(bloodGroups => new GenericEntityResponseDTO()
        {
            Id = bloodGroups.Id,
            Title = bloodGroups.Title
        }).ToList();
    }
}
