using MailService.Models;

namespace MailService.Repositories
{
    public interface IMailRepository
    {
        /// <summary>
        /// Асинхронно создает новую запись о письме в базе данных.
        /// </summary>
        /// <param name="mailRecordModel">Модель записи, содержащая данные о письме.</param>
        public Task CreateMailAsync(MailRecordModel mailRecordModel);
        /// <summary>
        /// Асинхронно получает список всех отправленных писем.
        /// </summary>
        /// <returns>Список моделей записей, содержащих информацию о каждом письме.</returns>
        public Task<List<MailRecordModel>> GetMailsAsync();
    }
}
