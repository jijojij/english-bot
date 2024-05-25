using English.Core.Communications;

namespace English.App;

public class TextMessageCommunication : ICommunication
{
    private readonly ITgDataService _tgDataService;

    public TextMessageCommunication(ITgDataService tgDataService)
    {
        _tgDataService = tgDataService;
    }

    public async Task Tell(CommunicationMethod communicationMethod)
    {
        await _tgDataService.SendMessage(communicationMethod, CancellationToken.None);
    }
}