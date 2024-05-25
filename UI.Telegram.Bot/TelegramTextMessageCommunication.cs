using English.Application.CommunicationWay;
using English.Core.Communications;
using UI.Telegram.Bot.TelegramBotDataService;

namespace UI.Telegram.Bot;

public class TelegramTextMessageCommunication(ITgDataService tgDataService) : ITextMessageCommunication
{
    public async Task Tell(CommunicationMethod communicationMethod, CancellationToken ct)
    {
        await tgDataService.SendMessage(communicationMethod, ct);
    }
}