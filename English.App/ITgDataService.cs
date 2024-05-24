using English.App.Action;
using English.Core.Communications;

namespace English.App;

public interface ITgDataService
{
    Task StartReceiving(TgWasAction handler, CancellationToken ct);
    Task SendMessage(CommunicationMethod communication, CancellationToken ct);
}