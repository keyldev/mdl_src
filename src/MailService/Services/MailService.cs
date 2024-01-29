using MailKit.Net.Smtp;
using MailService.Models;
using MailService.Repositories;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.Diagnostics;

namespace MailService.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _mailConfig;
        private readonly IMailRepository _mailRepository;


        public MailService(IConfiguration mailConfiguration, IMailRepository mailRepository)
        {
            _mailConfig = mailConfiguration;
            _mailRepository = mailRepository;

        }

        public async Task<List<MailRecordModel>> GetMailsAsync()
        {
            var mails = await _mailRepository.GetMailsAsync();
            return mails;
        }

        public async Task<MailResponseModel> SendMailAsync(MailRequestModel mailRequest)
        {
            try
            {
                var email = CreateEmail(mailRequest);
                await SendEmail(email);
                await SaveMailRecord(mailRequest, "OK", "");
                return new MailResponseModel()
                {
                    Message = "Mail sent successfully"
                };
            }
            catch (Exception ex)
            {
                await SaveMailRecord(mailRequest, "Failed", ex.Message);
                return new MailResponseModel
                {
                    Message = "Error while sending email: " + ex.Message
                };
            }
        }

        private MimeMessage CreateEmail(MailRequestModel mailRequest)
        {
            var email = new MimeMessage();
            if (MailboxAddress.TryParse(_mailConfig["MailConfig:Email"], out var address))
            {
                email.From.Add(address);
                email.To.AddRange(mailRequest.Recipients.Select(r => MailboxAddress.Parse(r)));
                email.Subject = mailRequest.Subject;
                email.Body = new TextPart("plain")
                {
                    Text = mailRequest.Body
                };
            }
            return email;
        }

        private async Task SendEmail(MimeMessage email)
        {
            var smtpClient = new SmtpClient();
            smtpClient.Connect(_mailConfig["MailConfig:SmtpServer"], int.Parse(_mailConfig["MailConfig:SmtpPort"]), MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
            smtpClient.Authenticate(_mailConfig["MailConfig:Email"], _mailConfig["MailConfig:Password"]);
            await smtpClient.SendAsync(email);
            await smtpClient.DisconnectAsync(true); // "cleanly" disconnect
        }

        private async Task SaveMailRecord(MailRequestModel mailRequest, string result, string failedMessage)
        {
            var mailRecord = new MailRecordModel
            {
                Subject = mailRequest.Subject,
                Body = mailRequest.Body,
                Recipients = mailRequest.Recipients.Select(mail => new RecipientModel(mail)).ToList(),
                CreatedAt = DateTime.UtcNow,
                Result = result,
                FailedMessage = failedMessage
            };
            await _mailRepository.CreateMailAsync(mailRecord);
        }
        
    }
}
