using BotPlatform.ClientApi;

namespace BotServiceModule;

#if (IsPolling)
public record BotServiceModuleOptions : BotServiceOptions;
#else
public record BotServiceModuleOptions : BotServiceOptions
{
    public Uri WebhookUrl { get; set; } = null!;

    public string WebhookToken { get; set; } = null!;
}
#endif