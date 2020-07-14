using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AvaliacaoInfnet.Domain.Mailer
{
    public class Mailer : IMailer
    {
        private readonly string email;
        private readonly string password;

        public void SendEmail(string to, string content, string subject)
        {
            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential(email, password);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(email);
                    mail.To.Add(to);
                    mail.Subject = subject;
                    mail.Body = content;
                    mail.BodyEncoding = Encoding.UTF8;

                    smtp.Send(mail);
                }
            }
        }

        public Mailer()
        {
            var configMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"MailerConfig\Mailer.config")
            };

            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            email = config.AppSettings.Settings[nameof(email)].Value;
            password = config.AppSettings.Settings[nameof(password)].Value;
        }

        public void EmailTest()
        {
            SendEmail("hiran.azevedo@vtex.com.br", "EMAIL TESTE", "EMail teste");
        }
    }
}
