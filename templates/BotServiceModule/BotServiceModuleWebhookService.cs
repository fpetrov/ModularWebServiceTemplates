using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace BotServiceModule;

public class BotServiceModuleWebhookService(
    [FromKeyedServices(nameof(BotServiceModuleWebhookService))] ITelegramBotClient botClient,
    IOptions<BotServiceModuleOptions> options,
    ILogger<BotServiceModuleWebhookService> logger)
    : BotPlatform.ClientApi.BotService
{
    public override Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Bot has been stopped.");
        return base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Telegram.Bot.Types.User me = await botClient.GetMe(stoppingToken);
        logger.LogInformation("Bot {MeFirstName} (@{MeUsername}) has been started!", me.FirstName, me.Username);

        string webhookUrl = options.Value.WebhookUrl.AbsoluteUri;
        await botClient.SetWebhook(
            webhookUrl,
            allowedUpdates: [],
            secretToken: options.Value.WebhookToken,
            cancellationToken: stoppingToken);
    }
}
