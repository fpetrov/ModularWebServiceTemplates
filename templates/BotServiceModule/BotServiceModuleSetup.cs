using BotPlatform.ClientApi;
using BotServiceModule.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;

namespace BotServiceModule;

public class BotServiceModuleSetup : IBotSetup<BotServiceModuleOptions>
{
    public void ConfigureServices(IServiceCollection services, BotServiceModuleOptions moduleOptions)
    {
        services.AddDbContext<BotServiceModuleDbContext>(o =>
            o.UseNpgsql(moduleOptions.DatabaseConnectionString));

        #if (!IsPolling)
        services.AddKeyedSingleton<ITelegramBotClient>(
            nameof(BotServiceModuleWebhookService),
            (_, _) => new TelegramBotClient(moduleOptions.TelegramBotToken));
        #endif
    }
}