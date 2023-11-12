using glasnost_back.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace glasnost_back.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from = null);
    }

    public class EmailService : IEmailService
    {
        private readonly AppSettings _appSettings;

        public EmailService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public void Send(string to, string subject, string html, string from = null)
        {
            try
            {
                // Cria a mensagem de e-mail
                MailMessage email = new MailMessage();
                email.From = new MailAddress("naoresponda.planner@gmail.com");
                email.To.Add(to);
                email.Subject = subject;
                email.Body = html;
                email.IsBodyHtml = true;
                email.BodyEncoding = Encoding.UTF8;
                email.SubjectEncoding = Encoding.UTF8;

                string smtpHost = _appSettings.SmtpHost;
                int smtpPort = _appSettings.SmtpPort;
                string smtpUsername = _appSettings.SmtpUser;
                string smtpPassword = _appSettings.SmtpPass;

                // Cria o cliente SMTP
                SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                smtpClient.Send(email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
            }
        }
    }
}
