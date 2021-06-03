using System;
using System.Net;
using System.Net.Mail;

using MonqTestJob.Email;

namespace MonqTestJob.Send
{
    /// <summary>
    /// Класс, с помощью которого происходит отправка сообщения по SMTP-протоколу
    /// </summary>
    public class SendMessage
    {
        /// <summary>
        /// Метод для отправки сообщения по SMTP-протоколу
        /// </summary>
        /// <param name="mail"> Объект типа "Сообщение" </param>
        public SendMessage( Mail mail)
        {
            MailAddress subj = new MailAddress(mail.Subject); 

            using (var message = new MailMessage())
            {
                message.From = subj;

                foreach (var email in mail.Recipient)
                {
                    message.To.Add(email.Trim('"'));
                }

                message.Body = mail.Body;

                mail.CreateDate = DateTime.Now;

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Host = Startup.Configuration.GetSection("SmtpHost").Value;
                    smtpClient.Port = Int32.Parse(Startup.Configuration.GetSection("SmtpPort").Value);
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential(Startup.Configuration.GetSection("SmtpLogin").Value, Startup.Configuration.GetSection("SmtpPassword").Value);

                    try
                    {
                        smtpClient.Send(message);
                        mail.Result = "OK";
                    }
                    catch (Exception ex)
                    {
                        mail.Result = "Failed";
                        mail.FailedMessage = ex.Message;
                    }

                    IMailRepository _mailRepository = new MailRepository();
                    _mailRepository.Create(mail);
                }
            }            
        }
    }
}
