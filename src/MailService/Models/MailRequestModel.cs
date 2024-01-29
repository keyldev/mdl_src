namespace MailService.Models
{
    public class MailRequestModel
    {
        /// <summary>
        /// Тема письма.
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Тело письма.
        /// </summary>
        public string? Body { get; set; }

        /// <summary>
        /// Список получателей письма.
        /// </summary>
        public List<string>? Recipients { get; set; }

    }
}
