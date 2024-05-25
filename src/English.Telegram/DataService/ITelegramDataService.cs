using English.Application.Routes.Models;
using English.Core.Communications;

namespace UI.Telegram.Bot.DataService;

public interface ITelegramDataService
{
    Task StartReceiving(TgWasAction handler, CancellationToken ct);
    Task SendMessage(CommunicationMethod communication, CancellationToken ct);
}