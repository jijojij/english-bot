namespace English.Application.Routes.Onboarding;

public class HandShake(long chatId, string userName)
{
    public long ChatId { get; } = chatId;
    public string UserName { get; } = userName;
}

public class NiceToMeetYou(long chatId, string userName, string preferName) : HandShake(chatId, userName)
{
    public string PreferName { get; } = preferName;
}