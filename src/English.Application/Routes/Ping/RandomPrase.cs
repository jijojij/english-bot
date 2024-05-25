using English.Application.Communications;
using English.Application.Routes.Models;
using English.Store;
using English.Store.Mappings;
using Microsoft.EntityFrameworkCore;

namespace English.Application.Routes.Ping;

public class Ping(
    EnglishDbContext englishDbContext,
    ICommunicationFactory communicationFactory)
{
    public async Task Pong(long chatId, CancellationToken ct)
    {
        var dbUser = await englishDbContext.Users.FirstOrDefaultAsync(x => x.TelegramChatId == chatId, cancellationToken: ct);
        if (dbUser is null)
            return;
        var communication = communicationFactory.CreateCommunication(ActionType.Message);

        await dbUser.ToDomain().Tell(communication, $"{dbUser.Name}, I still can't do anything! If you tries '/register' i don't can show anything :c", ct);
    }
}