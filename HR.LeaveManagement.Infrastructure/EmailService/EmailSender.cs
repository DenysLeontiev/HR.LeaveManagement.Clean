using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Models;
using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace HR.LeaveManagement.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; }

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings.ApiKey = emailSettings.Value.ApiKey;
            _emailSettings.FromName = emailSettings.Value.FromName;
            _emailSettings.FromAddress = emailSettings.Value.FromAddress;
        }

        public async Task<bool> SendEmail(EmailMessage email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return response.IsSuccessStatusCode;
        }
    }
}
