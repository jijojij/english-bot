using English.Core.Users;
using English.Store;

namespace English.Application.StateManager;

public class UserStateManager(EnglishDbContext englishDbContext)
{
    public UserState GetCurrentState(long chatId)
    {
        var user = englishDbContext.Users.FirstOrDefault(u => u.TelegramChatId == chatId);
        return user?.State ?? UserState.Nothing;
    }
}

