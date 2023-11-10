using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.Common
{
    public class MailDTO
    {
        public string ToEmail { get; set; } = String.Empty;

        public string Subject { get; set; } = String.Empty;

        public string Body { get; set; } = String.Empty;

        public List<IFormFile> Attachments { get; set; } = new List<IFormFile>();
    }
}
