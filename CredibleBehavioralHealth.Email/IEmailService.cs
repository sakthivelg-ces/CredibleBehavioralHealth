using System.Collections.Generic;
using System.Net.Mail;

namespace CredibleBehavioralHealth.Email
{
    public interface IEmailService
    {
        void SendWithImage(List<string> to, string subject, string body, byte[] imageBytes);
    }
}
