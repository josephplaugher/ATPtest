using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace ATPEmailNotifications
{
    public class EmailNotification
    {
        private readonly IConfiguration config;

        public EmailNotification(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<string> NewEmail(string recipientName, string recipientEmail, string initiatorName, string initiatorEmail, string message)
        {
            var client = new SendGridClient(this.config["OneViewROW_apiKey"]);
            var from = new EmailAddress(initiatorEmail, initiatorName);
            var subject = "Testing Email API";
            var to = new EmailAddress(recipientEmail, recipientName);
            var textNotificationMessage = message;
            var htmlnotificationMessage = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, textNotificationMessage, htmlnotificationMessage);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            System.Console.WriteLine($"Response: {response.StatusCode}");
            return $"Attempted email result: {response.StatusCode}";
        }
    }
}
