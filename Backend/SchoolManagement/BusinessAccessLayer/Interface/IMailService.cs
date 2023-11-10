using Entities.DTOs.Common;

namespace BusinessAccessLayer.Interface
{
    public interface IMailService
    {
        Task SendMailAsync(MailDTO mailData, CancellationToken cancellationToken = default);
    }
}
