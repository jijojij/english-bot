using English.App.Action;
using English.Core.Communications;

namespace English.App;

public class Catch(ITgDataService dataService)
{
    public async Task CatchMessage(WasAction action, CancellationToken ct)
    {
        Console.WriteLine("catched message: " + action.Data);

        await dataService.SendMessage(new CommunicationMethod(action.MetaData.ChatId, "Hello!"), ct);
    }
}