namespace MailService.Models
{
    public class MailRecordModel
    {
        /// <summary>
        /// Уникальный идентификатор письма.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Тема письма.
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Тело письма.
        /// </summary>
        public string? Body { get; set; }

        /// <summary>
        /// Результат отправки письма.
        /// </summary>
        public string? Result { get; set; }

        /// <summary>
        /// Сообщение об ошибке, если письмо не было отправлено.
        /// </summary>
        public string? FailedMessage { get; set; }

        /// <summary>
        /// Дата и время создания письма.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Коллекция получателей письма.
        /// </summary>
        public virtual ICollection<RecipientModel>? Recipients { get; set; }
    }
}
