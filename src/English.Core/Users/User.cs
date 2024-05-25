using English.Core.Communications;

namespace English.Core.Users;

public sealed class User(Guid userId, long chatId)
{
    public User(Guid userId, long chatId, string? name) : this(userId, chatId)
    {
        Name = name;
    }
    
    public Guid UserId { get; } = userId;
    public long ChatId { get; } = chatId;
    public string? Name { get; }

    public Task Tell(ICommunication communication, string message, CancellationToken ct)
    {
        return communication.Tell(new CommunicationMethod(ChatId, message), ct);
    }
}