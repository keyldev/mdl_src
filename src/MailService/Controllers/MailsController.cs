using MailKit;
using MailService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {

        private readonly MailService.Services.IMailService _mailService;
        public MailsController(MailService.Services.IMailService mailService)
        {
            _mailService = mailService;
        }

        /// <summary>
        /// Асинхронно отправляет электронное письмо по указанному запросу.
        /// </summary>
        /// <param name="mailRequest">Модель запроса, содержащая данные для отправки письма.</param>
        /// <returns>Объект ActionResult, содержащий модель ответа с результатом отправки письма.</returns>
        [HttpPost]
        public async Task<IActionResult> SendMailAsync([FromBody] MailRequestModel mailRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mailResult = await _mailService.SendMailAsync(mailRequest);
            return Ok(mailResult);
        }

        /// <summary>
        /// Асинхронно получает список всех отправленных писем.
        /// </summary>
        /// <returns>Объект ActionResult, содержащий список моделей записей с информацией о каждом письме.</returns>
        [HttpGet]
        public async Task<IActionResult> GetMailsAsync()
        {
            var emails = await _mailService.GetMailsAsync();

            return Ok(emails);
        }

    }
}
