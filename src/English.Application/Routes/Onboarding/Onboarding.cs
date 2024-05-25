using English.Application.Communications;
using English.Application.Routes.Models;
using English.Core.Users;
using English.Store;
using English.Store.Mappings;
using Microsoft.EntityFrameworkCore;

namespace English.Application.Routes.Onboarding;

public class Onboarding(ICommunicationFactory communicationFactory, EnglishDbContext dbContext)
{
    public async Task HandShake(HandShake handShake, CancellationToken ct)
    {
        var user = new User(Guid.NewGuid(), handShake.ChatId);
        var dbUser = user.CreateNewDb(handShake.UserName);
        await dbContext.Users.AddAsync(dbUser, ct);
        await dbContext.SaveChangesAsync(ct);
        
        var communication = communicationFactory.CreateCommunication(ActionType.Message);
        await user.Tell(communication, "Hi! I'm an English bot for Grinenko family c:\nHow can I tell you?", ct);
    }

    public async Task NiceToMeetYou(NiceToMeetYou niceToMeetYou, CancellationToken ct)
    {
        var dbUser = await dbContext.Users.FirstAsync(x => x.TelegramChatId == niceToMeetYou.ChatId, ct);
        dbUser.Name = niceToMeetYou.PreferName;
        await dbContext.SaveChangesAsync(ct);
        
        var user = dbUser.ToDomain();
        var communication = communicationFactory.CreateCommunication(ActionType.Message);
        await user.Tell(communication, $"Nice to meet you, {user.Name}!", ct);
    }
}