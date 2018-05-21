using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Configuration;
using System;
using System.Globalization;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;

namespace CredibleBehavioralHealth.Email
{
    public class EmailService : IEmailService
    {
        private SmtpClient _smtpClient;
        private MailAddress _fromMailAddress;

        public EmailService()
        {
            
            string host = ConfigurationManager.AppSettings["SMTPHost"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"], CultureInfo.InvariantCulture);

            string userName = ConfigurationManager.AppSettings["SMTPUserName"];
            string password = ConfigurationManager.AppSettings["SMTPPassword"];

            string fromMailAddress = ConfigurationManager.AppSettings["FromEmail"];

            _smtpClient = new SmtpClient(host, port);
            _smtpClient.Credentials = new System.Net.NetworkCredential(userName, password);
            _smtpClient.EnableSsl = true;

            _fromMailAddress = new MailAddress(fromMailAddress);
        }

        public void Send(MailMessage mailMessage)
        {
            ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate,
                     X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };

            _smtpClient.Send(mailMessage);
        }

        public void SendWithImage(List<string> to, string subject, string body, byte[] imageBytes)
        {
            MailMessage mailMessage = new MailMessage();

            foreach (var mail in to)
            {
                mailMessage.To.Add(mail);
            }
            mailMessage.Subject = subject;
            mailMessage.From = _fromMailAddress;

            LinkedResource image = new LinkedResource(new MemoryStream(imageBytes));
            image.ContentId = "Image";
            body = body + "<br><html><body><img src=\"cid:Image\"/>";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(image);

            mailMessage.AlternateViews.Add(alternateView);
            Task.Run(() => this.Send(mailMessage));
        }
    }
}
