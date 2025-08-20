using BotPlatform.ClientApi;
using BotServiceModule.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace BotServiceModule;

public class BotServiceModulePollingService(
    IServiceProvider provider,
    IOptions<BotServiceModuleOptions> options,
    ILogger<BotServiceModulePollingService> logger) : BotService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (IServiceScope scope = provider.CreateScope())
        {
            BotServiceModuleDbContext context = scope.ServiceProvider.GetRequiredService<BotServiceModuleDbContext>();
            await context.Database.MigrateAsync(stoppingToken);
        }

        ReceiverOptions receiverOptions = new()
        {
            AllowedUpdates = []
        };

        ITelegramBotClient botClient =
            new TelegramBotClient(new TelegramBotClientOptions(options.Value.TelegramBotToken));
        botClient.StartReceiving(HandleUpdate, HandleError, receiverOptions, stoppingToken);
    }

    private Task HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        return Task.Run(() => ProcessUpdate(botClient, update, cancellationToken), cancellationToken);
    }

    private async Task ProcessUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is null)
        {
            return;
        }

        long chatId = update.Message.Chat.Id;
        await botClient.SendMessage(chatId, "Hello from BotServiceModule!", cancellationToken: cancellationToken);
    }

    private Task HandleError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Error occurred!");
        return Task.CompletedTask;
    }
}