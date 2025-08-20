using BotPlatform.RunApi;
using BotServiceModule;

#if (IsPolling)
var builder = Host.CreateApplicationBuilder(args);
#else
var builder = WebApplication.CreateBuilder(args);
#endif

builder.Services.SetupBotPlatform(builder.Configuration);

#if (IsPolling)
builder.Services.AddBot<BotServiceModulePollingService, BotServiceModuleOptions>(
    builder.Configuration,
    new BotServiceModuleSetup()
);
#else
builder.Services.AddBot<BotServiceModuleWebhookService, BotServiceModuleOptions>(
    builder.Configuration,
    new BotServiceModuleSetup()
);
#endif

#if (!IsPolling)
builder.Services.AddControllers();
#endif

var app = builder.Build();

#if (!IsPolling)
app.MapControllers();
#endif

app.Run();