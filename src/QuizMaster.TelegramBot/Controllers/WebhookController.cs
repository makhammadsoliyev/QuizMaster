using Microsoft.AspNetCore.Mvc;
using QuizMaster.TelegramBot.Services;
using Telegram.Bot.Types;


namespace QuizMaster.TelegramBot.Controllers;

public class WebhookController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromServices] HandleUpdateService handleUpdateService,
                                          [FromBody] Update update)
    {
        await handleUpdateService.EchoAsync(update);

        return Ok();
    }
}
