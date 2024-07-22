using Entities.DataModels;
using Entities.DTOs;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class MediumMappingProfile
{
    public static List<GenericEntityResponseDTO> ToGenericEntityResponseDTOs(this IEnumerable<Medium> mediums)
    {
        return mediums.Select(mediums => new GenericEntityResponseDTO()
        {
            Id = mediums.Id,
            Title = mediums.Title
        }).ToList();
    }
}
