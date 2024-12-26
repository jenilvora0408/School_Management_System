using Common.Constants;
using Entities.DataModels;
using Entities.DTOs;

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

     public static Document ToDocument(this ManageChapterDocumentDTO dto, int courseId)
    {
        return new Document
        {
            DocumentContent = dto.DocumentContent ?? string.Empty,
            CourseId = courseId,
            UseDocumentFor = SystemConstants.USE_DOCUMENT_FOR_CHAPTER_DOCUMENT,
        };
    }

    public static void UpdateFromDTO(this Document document, ManageChapterDocumentDTO dto)
    {
        document.DocumentContent = dto.DocumentContent ?? document.DocumentContent;
        document.UseDocumentFor = SystemConstants.USE_DOCUMENT_FOR_CHAPTER_DOCUMENT;
    }

    public static GetChapterDocumentDTO ToGetDocument(this Document document)
    {
        return new GetChapterDocumentDTO
        {
            DocumentId = document.Id,
            DocumentContent = document.DocumentContent,
            CourseId = document.CourseId,
            UseDocumentFor = document.UseDocumentFor
        };
    }

    public static List<Document> ToDocuments(this IEnumerable<DocumentDTO> documentDTOs, int courseId)
    {
        return documentDTOs.Select(dto => new Document
        {
            DocumentContent = dto.DocumentContent,
            DocumentName = dto.DocumentName,
            DocumentType = dto.DocumentType,
            DocumentExtension = dto.DocumentExtension,
            CourseId = courseId,
            UseDocumentFor = SystemConstants.USE_DOCUMENT_FOR_CHAPTER_DOCUMENT
        }).ToList();
    }
}
