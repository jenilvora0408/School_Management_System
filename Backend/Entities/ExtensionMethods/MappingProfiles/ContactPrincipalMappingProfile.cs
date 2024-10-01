using Entities.DataModels;
using Entities.DTOs;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class ContactPrincipalMappingProfile
{
    public static ContactPrincipal ToContactPrincipal(this ContactPrincipalDTO contactPrincipalDTO) => new()
    {
        UserId = contactPrincipalDTO.UserId,
        Subject = contactPrincipalDTO.Subject,
        Description = contactPrincipalDTO.Description,
        RequestDate = DateTime.UtcNow,
        Type = contactPrincipalDTO.Type,
        IsResolved = false,
        RelatableEvidence = contactPrincipalDTO.RelatableEvidence,
    };
}
