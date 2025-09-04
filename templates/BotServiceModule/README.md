# BotService Module

![.NET](https://img.shields.io/badge/.NET-8%2F9-blueviolet?logo=dotnet&logoColor=white)
![License](https://img.shields.io/badge/license-MIT-green)

## About
**BotService Module** is a .NET project template for building a Telegram bot service. It can scaffold either a **Polling** worker or a **Webhook**-based ASP.NET Core controller setup.

## At a glance
- **Short name:** `bot`
- **Source name token:** `BotServiceModule` (replaced with your project name)
- **Project type:** C# *project*
- **Default mode:** `Polling`

## Quick start

### Create a new bot (Polling — default)
```bash
dotnet new bot -n MyTelegramBot
# or explicitly
dotnet new bot -n MyTelegramBot --BotType Polling
```

### Create a new bot (Webhook)
```bash
dotnet new bot -n MyTelegramBot.Webhook --BotType Webhook
```

## Template parameters

| Parameter    | Type    | Default   | Values                 | Description                                   |
|--------------|---------|-----------|------------------------|-----------------------------------------------|
| `--BotType`  | choice  | `Polling` | `Polling`, `Webhook`   | Select how the bot receives updates.          |

> Internally the template computes flags `IsPolling` and `IsWebhook` based on `--BotType` to control which files are included.

## Conditional content (what gets generated)
Depending on the selected `--BotType`, the template includes/excludes files:

| Mode      | Included                                  | Excluded                                      |
|-----------|--------------------------------------------|-----------------------------------------------|
| Polling   | `BotServiceModulePollingService.cs`        | `Controllers/**`, `BotServiceModuleWebhookService.cs` |
| Webhook   | `Controllers/**`, `BotServiceModuleWebhookService.cs` | `BotServiceModulePollingService.cs`           |

## Folder layout (illustrative)
```
MyTelegramBot/
 ├─ BotServiceModulePollingService.cs      # Polling only
 ├─ BotServiceModuleWebhookService.cs      # Webhook only
 ├─ Controllers/                           # Webhook only
 └─ ...
```

## Naming & directory
The template prefers creating a directory with your chosen name (`--name` / `-n`) and replaces all occurrences of the `BotServiceModule` token with that name.

## Next steps
- Provide your **Telegram Bot Token** via configuration or secrets.
- If using **Webhook**, expose an HTTPS endpoint and configure the webhook with Telegram.
- If using **Polling**, run the background worker where your app is hosted.
