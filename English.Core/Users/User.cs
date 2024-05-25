namespace English.Core.Users;

public sealed class User(Guid userId, string name,  long chatId)
{
    public Guid UserId { get; } = userId;
    public string Name { get; } = name;

    public long ChatId { get; } = chatId;
}