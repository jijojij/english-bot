using English.Application.Action;
using English.Core.Communications;

namespace UI.Telegram.Bot.TelegramBotDataService;

public interface ITgDataService
{
    Task StartReceiving(TgWasAction handler, CancellationToken ct);
    Task SendMessage(CommunicationMethod communication, CancellationToken ct);
}