using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using MonqTestJob.Send;
using MonqTestJob.Email;
using System.Text.Json;

namespace MonqTestJob.Pages
{

    /// <summary>
    /// Класс модели для страницы Razor
    /// который обрабатывает Get и Post запросы к странице
    /// </summary>

    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMailRepository _mailRepository = new MailRepository();

        /// <summary>
        /// Создание нового объекта типа "Сообщение"
        /// </summary>
        public string Mails { get; set; }        

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Метод, обрабатываеющтй Get-запрос к странице, и возвращающий список сообщений из БД в формате Json
        /// </summary>
        /// <returns>Возвращает список объектов типа "Сообщение" из БД в формате Json</returns>
        public JsonResult OnGet()
        {
            List<Mail> mails = (List<Mail>)_mailRepository.GetMails();
            string jsonResult = "";

            try
            {
                foreach (var item in mails)
                {
                    string jsonItem = JsonSerializer.Serialize<Mail>(item);
                    jsonResult += jsonItem;
                }
            }
            catch (System.Exception)
            {
                jsonResult = "";
            }
            
            return new JsonResult(jsonResult);
        }

        /// <summary>
        /// Метод, обрабатывающий POST запрос к странице, содержащий Json
        /// </summary>
        /// <param name="obj"> Объект, представляющий Json, который пришел в теле запроса </param>
        public void OnPost([FromBody] JsonDocument obj)
        {
            string subject = obj.RootElement.GetProperty("subject").ToString();
            string body = obj.RootElement.GetProperty("body").ToString();
            string recipients = obj.RootElement.GetProperty("recipients").ToString();
            recipients = recipients.Replace("[", "");
            recipients = recipients.Replace("]", "");
            recipients = recipients.Replace("\\", "");
            string[] recipient = recipients.Split(',');

            Mail mail = new Mail { Subject = subject, Body = body, Recipient = recipient.ToList<string>() };

            SendMessage send = new SendMessage(mail);
        }
    }
}
