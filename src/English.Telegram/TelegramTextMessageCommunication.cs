using English.Application.Communications;
using English.Core.Communications;
using UI.Telegram.Bot.DataService;

namespace UI.Telegram.Bot;

public class TelegramTextMessageCommunication(ITelegramDataService telegramDataService) : ITextMessageCommunication
{
    public async Task Tell(CommunicationMethod communicationMethod, CancellationToken ct)
    {
        await telegramDataService.SendMessage(communicationMethod, ct);
    }
}