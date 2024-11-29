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
    };

    public static List<GetContactPrincipalListDTO> ToGetContactPrincipalList(this List<ContactPrincipal> contactPrincipals)
    {
        return contactPrincipals.Select(contactPrincipal => contactPrincipal.ToGetContactPrincipalData()).ToList();
    }

    public static GetContactPrincipalListDTO ToGetContactPrincipalData(this ContactPrincipal contactPrincipal)
    {
        return new GetContactPrincipalListDTO
        {
            ContactPrincipalId = contactPrincipal.Id,
            UserId = contactPrincipal.UserId,
            Subject = contactPrincipal.Subject,
            Description = contactPrincipal.Description,
            RequestDate = contactPrincipal.RequestDate,
            Type = contactPrincipal.Type,
            IsResolved = contactPrincipal.IsResolved,
            ResponseMessage = contactPrincipal.ResponseMessage,
            UserName = $"{contactPrincipal.Users.FirstName} {contactPrincipal.Users.LastName}",
            ContactTypeTitle = contactPrincipal.ContactOfType.ContactTitle,
            UserRole = contactPrincipal.Users.UserRoles.Title
        };
    }

    public static void ToPostPrincipalResponse(ContactPrincipal contactPrincipal, ContactPrincipalResponseDTO contactPrincipalDTO)
    {
        contactPrincipal.ResponseMessage = contactPrincipalDTO.ResponseMessage;
        contactPrincipal.IsResolved = true;
    }
}
