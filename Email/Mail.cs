using System;
using System.Collections.Generic;

namespace MonqTestJob.Email
{

    /// <summary>
    /// Класс, определяющий свойства объекта типа "Сообщение"
    /// </summary>
    public class Mail
    {
        /// <summary>
        /// Свойсто, определяющее Id объекта в БД
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство, определяющее отправителя сообщения
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Свойство, определяющее содержание сообщения
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Свойство, определяющее список получателей сообщения
        /// </summary>
        public List<string> Recipient { get; set; }

        /// <summary>
        /// Свойство, определяющее дату создания сообщения
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Свойство, определяющее результат отправки сообщения
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Свойство, определяющее (при наличии) текст ошибки при отправке сообщения
        /// </summary>
        public string FailedMessage { get; set; }
    }
}
