using System.Collections.Generic;

namespace MonqTestJob.Email
{
/// <summary>
/// Интерфейс репозитория для обработки объектов типа "Сообщиения" посредством Dapper
/// </summary>
    public interface IMailRepository
    {
        /// <summary>
        /// Объявление метода для создания объекта
        /// </summary>
        /// <param name="mail"> Объект типа "Сообщение" </param>
         void Create(Mail mail);

        /// <summary>
        /// Метод для получения списка всех сообщений
        /// </summary>
        /// <returns>Возвращает список всех объектов типа "Сообщение" из БД</returns>
         IEnumerable<Mail> GetMails();
    }
}
