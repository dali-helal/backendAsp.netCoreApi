using backend.Dtos.Email;
using backend.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace backend.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;
        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings= smtpSettings.Value;
        }
        public async Task SendEmailAsync(SendEmailDto emailModel)
        {   
            var cred=new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password); 
            var smptClient = new SmtpClient(_smtpSettings.Host)
            {
                EnableSsl = _smtpSettings.EnableSsl,
                Port = _smtpSettings.Port,
                Credentials = cred
            };
            var mailMessage= new MailMessage
            {
                From= new MailAddress(_smtpSettings.UserName),
                Subject=emailModel.Subject,
                Body=emailModel.Body,
                IsBodyHtml=true,
            };
             mailMessage.To.Add(emailModel.To);

             await smptClient.SendMailAsync(mailMessage);
        }
    }
}
