using English.App.Action;
using English.App.CommunicationWay;
using English.Core.Users;
using English.Store;

namespace English.App;

public class Catch(CommunicationWayFactory communicationWayFactory, IStore store)
{
    public async Task CatchMessage(WasAction action, CancellationToken ct)
    {
        Console.WriteLine("catched message: " + action.Data);

        await store.UserRepository.Add(new User(Guid.NewGuid(), action.MetaData.UserName!, action.MetaData.ChatId));
    }
    
    public async Task Test(string name)
    {
        var user = await store.UserRepository.Get(name);
        if (user is null)
            return;

        var communication = communicationWayFactory.GetCommunicationWay(CommunicationWay.App.Telegram, ActionType.Message);

        await user.Tell(communication, "");
    }
}