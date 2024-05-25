using English.App.Action;
using English.Core.Communications;
using English.Core.Users;
using English.Store;

namespace English.App;

public class Catch(ITgDataService dataService, IStore store)
{
    public async Task CatchMessage(WasAction action, CancellationToken ct)
    {
        Console.WriteLine("catched message: " + action.Data);
        

        await dataService.SendMessage(new CommunicationMethod(action.MetaData.ChatId, "Hello!"), ct);

        await store.UserRepository.Add(new User(Guid.NewGuid(), action.MetaData.UserName!, action.MetaData.ChatId));
    }
    
    public async Task Test(string name)
    {
        var user = await store.UserRepository.Get(name);
        if (user is null)
            return;
        
        await dataService.SendMessage(new CommunicationMethod(user.ChatId, "ТЫ ЧОРТ"), CancellationToken.None);
    }
}