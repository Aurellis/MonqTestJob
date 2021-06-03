using System;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace MonqTestJob.Email
{
    /// <summary>
    /// Класс, реализующий интерфейс IMailRepository
    /// </summary>
    public class MailRepository : IMailRepository
    {
        private readonly string _connectionString = Startup.Configuration.GetSection("ConnectionString").Value;

        /// <summary>
        /// Метод для создания сообщения в БД, принимает объект типа "Сообщение"
        /// </summary>
        /// <param name="mail"> Объект типа "Сообщение" </param>
        public void Create(Mail mail)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var sqlQuery = "INSERT INTO [dbo].[mails] ([subject], [body], [recipients], [createdate], [result], [failedmessage])" +
                                          "VALUES(@Subject, @Body, @Recipient, @CreateDate, @Result, @FailedMessage)";
                    db.Execute(sqlQuery, mail);
                }
            }
            catch (Exception ex)
            {
                string mess = ex.Message;
            }
        }

        /// <summary>
        /// Метод для получения списка всех объектов типа "Сообщение" из БД
        /// </summary>
        /// <returns>Возвращает коллецию всех объектов типа "Сообщение", содержащихся в БД</returns>
        public IEnumerable<Mail> GetMails()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    return db.Query<Mail>("select * from [dbo].[mails]");
                }
            }
            catch (Exception ex)
            {
                string mess = ex.Message;
                return null;
            }
        }
    }
}
