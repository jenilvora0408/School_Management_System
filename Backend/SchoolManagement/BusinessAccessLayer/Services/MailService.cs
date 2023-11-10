using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Common.Constants;
using Microsoft.AspNetCore.Http;
using BusinessAccessLayer.Interface;
using Entities.DTOs.Common;

namespace BusinessAccessLayer.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettingsDTO _mailSetting;
        public MailService(IOptions<MailSettingsDTO> mailSetting)
        {
            _mailSetting = mailSetting.Value;
        }

        public async Task SendMailAsync(MailDTO mailData, CancellationToken cancellationToken = default)
        {
            MimeMessage email = new();
            email.Sender = MailboxAddress.Parse(_mailSetting.Mail);
            email.To.Add(MailboxAddress.Parse(mailData.ToEmail));
            email.Subject = !String.IsNullOrEmpty(mailData.Subject) ? mailData.Subject : EmailConstants.GENERIC_SUBJECT;

            var builder = new BodyBuilder();
            if (mailData.Attachments != null && mailData.Attachments.Count!=0)
            {
                byte[] fileBytes;
                foreach (var file in mailData.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailData.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSetting.Host, _mailSetting.Port, SecureSocketOptions.StartTls, cancellationToken);
            smtp.Authenticate(_mailSetting.Mail, _mailSetting.Password, cancellationToken);
            await smtp.SendAsync(email, cancellationToken);
            smtp.Disconnect(true, cancellationToken);
        }

        public async Task<IFormFile> ConvertByteToFormFile(byte[] byteFile,string fileName)
        {
            var ms= new MemoryStream(byteFile);
            var file = new FormFile(ms, 0, ms.Length, "School Management System", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/pdf"
            };
            return  file;   
        }

        public async Task<List<IFormFile>> ConvertByteListToFormFiles(FileConversionDTO fileConversionDTO)
        {
            List<IFormFile> formFiles = new List<IFormFile>();

            for (int i = 0; i < fileConversionDTO.ByteFiles.Count; i++)
            {
                var ms = new MemoryStream(fileConversionDTO.ByteFiles[i]);
                var file = new FormFile(ms, 0, ms.Length, "School Management System", fileConversionDTO.FileNames[i])
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/pdf"
                };

                formFiles.Add(file);
            }

            return formFiles;
        }


    }
}
