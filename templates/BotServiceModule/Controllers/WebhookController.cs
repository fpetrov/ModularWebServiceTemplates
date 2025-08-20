using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace BotServiceModule.Controllers;

[ApiController]
[Route("api/webhook")]
public class WebhookController(IOptions<BotServiceModuleOptions> options) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> HandleWebhook(
        [FromBody] Update update,
        [FromKeyedServices(nameof(BotServiceModuleWebhookService))] ITelegramBotClient bot,
        [FromKeyedServices(nameof(BotServiceModuleWebhookService))] IUpdateHandler updateHandler,
        CancellationToken cancellationToken)
    {
        if (Request.Headers["X-Telegram-Bot-Api-Secret-Token"] != options.Value.WebhookToken)
        {
            return StatusCode(403);
        }

        try
        {
            await updateHandler.HandleUpdateAsync(bot, update, cancellationToken);
        }
        catch (Exception exception)
        {
            await updateHandler.HandleErrorAsync(bot, exception, HandleErrorSource.HandleUpdateError, cancellationToken);
        }

        return Ok();
    }

}