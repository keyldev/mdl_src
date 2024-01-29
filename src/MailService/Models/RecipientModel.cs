using System.Text.Json.Serialization;

namespace MailService.Models
{
    public class RecipientModel
    {
        /// <summary>
        /// Уникальный идентификатор получателя.
        /// </summary>
        [JsonIgnore]
        public Guid Id { get; set; }

        /// <summary>
        /// Адрес электронной почты получателя.
        /// </summary>
        [JsonPropertyName("recipient")]
        public string? Email { get; set; }

        /// <summary>
        /// Уникальный идентификатор письма, которому принадлежит получатель.
        /// </summary>
        [JsonIgnore]
        public Guid MailId { get; set; }

        /// <summary>
        /// Ссылка на письмо, которому принадлежит получатель.
        /// </summary>
        [JsonIgnore]
        public MailRecordModel? Mail { get; set; }

        public RecipientModel(string email)
        {
            Email = email;
        }

    }
}
