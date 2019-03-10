using identity.Models.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Linq;
using System.Threading.Tasks;

namespace WebPWrecover.Services
{
    public class EmailSender : IEmailSender
    {
        private Configurations _config;
        public EmailSender(ApplicationDbContext context)
        {
            _config = context.Configurations.Single(c => c.ConfigurationID == 1);



        }

        //public Configurations Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        { 
            return Execute(_config.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
           

            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_config.SendGridUser, "Do not Reply"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}