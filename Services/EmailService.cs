using glasnost_back.Helpers;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System;

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
                // create message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(from ?? "Planner - Bullest <naoresponda.planner@gmail.com>"));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;

                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = @"
                        <!doctype html>
                        <html lang='en'>
                        <head>
                          <meta charset='utf-8'>
                        </head>
                        <body>
                            " + html + @"
                        </body>
                        </html>
                    "
                };

                // send email
                using var smtp = new SmtpClient();
                smtp.Connect(_appSettings.SmtpHost, _appSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
                smtp.Send(email);
                smtp.Disconnect(true);
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
