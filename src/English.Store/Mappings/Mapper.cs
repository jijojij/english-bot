using English.Store.Models;
using User = English.Core.Users.User;

namespace English.Store.Mappings;

public static class Mapper
{
    public static Models.User CreateNewDb(this User domain, string userName)
    {
        return new Models.User()
        {
            Id = domain.UserId,
            TelegramUserName = userName,
            TelegramChatId = domain.ChatId,
            CreatedAtUtc = DateTime.UtcNow,
            State = domain.State
        };
    }
    
    public static User ToDomain(this Models.User db)
    {
        return new User(db.Id, db.TelegramChatId, db.Name, db.State);
    }
}