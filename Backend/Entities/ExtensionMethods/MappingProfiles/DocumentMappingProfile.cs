using Common.Constants;
using Entities.DataModels;

namespace Entities.ExtensionMethods.MappingProfiles;

public static class DocumentMappingProfile
{
    public static List<Document> ToDocumentList(this IEnumerable<string> documentContents, int contactPrincipalId)
    {
        return documentContents.Select(content => new Document
        {
            DocumentContent = content,
            UseDocumentFor = SystemConstants.USE_DOCUMENT_FOR_CONTACT_PRINCIPAL,
            ContactPrincipalId = contactPrincipalId
        }).ToList();
    }
}
