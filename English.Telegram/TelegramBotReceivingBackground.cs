using English.Application.Routes;
using JetBrains.Annotations;
using UI.Telegram.Bot.DataService;

namespace UI.Telegram.Bot;

[UsedImplicitly]
public class TelegramBotReceivingBackground(
    Router router,
    ITelegramDataService telegramDataService)
{
    public async Task Start(CancellationToken ct)
    {
        await telegramDataService.StartReceiving(router.Route, ct);
    }
}