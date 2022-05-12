using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace TicketVerkoop.Util.Mail
{
    public interface IEmailSend
    {
        Task SendEmailAsync(string email, string subject, string message, byte[] pdf);
    }

    public class EmailSend : IEmailSend
    {
        private readonly EmailSettings _emailSettings;
        public EmailSend(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task SendEmailAsync(
            string email, string subject, string message, byte[] pdf)
        {
            var mail = new MailMessage();  // aanmaken van een mail‐object
            mail.To.Add(new MailAddress(email));
            MemoryStream stream = new MemoryStream(pdf);
            Attachment data = new Attachment(stream, "information.pdf");
            mail.Attachments.Add(data);

            mail.From = new
                    MailAddress("michiel.devaere101@gmail.com");  // hier komt jullie Gmail‐adres
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            try
            {
                using (var smtp = new SmtpClient(_emailSettings.MailServer))
                {
                    smtp.Port = _emailSettings.MailPort;
                    smtp.EnableSsl = true;
                    smtp.Credentials =
                        new NetworkCredential(_emailSettings.Sender,
                                                _emailSettings.Password);
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
