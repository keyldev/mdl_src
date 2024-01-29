using MailService.Models;

namespace MailService.Services
{
    public interface IMailService
    {
        /// <summary>
        /// Асинхронно отправляет электронное письмо по указанному запросу.
        /// </summary>
        /// <param name="request">Модель запроса, содержащая данные для отправки письма.</param>
        /// <returns cref="MailResponseModel">Модель ответа, содержащая результат отправки письма.</returns>
        /// <exception cref="MailKit.Security.AuthenticationException">При невалидных данных SMTP</exception>
        /// <exception cref="ArgumentNullException">При невалидных данных Email</exception>
        /// <exception cref="ParseException">Неправильные данные Email</exception>
        public Task<MailResponseModel> SendMailAsync(MailRequestModel request);
        /// <summary>
        /// Асинхронно получает список всех отправленных писем.
        /// </summary>
        /// <returns>Список моделей записей, содержащих информацию о каждом письме.</returns>
        public Task<List<MailRecordModel>> GetMailsAsync();
    }
}
