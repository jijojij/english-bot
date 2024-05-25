using English.Core.Communications;

namespace English.Core.Users;

public sealed class User
{
    public User(Guid userId, long chatId)
    {
        UserId = userId;
        ChatId = chatId;
        State = UserState.Onboarding;
    }

    public User(Guid userId, long chatId, string? name, UserState state) : this(userId, chatId)
    {
        Name = name;
        State = state;
    }

    public Guid UserId { get; }
    public long ChatId { get; }
    public string? Name { get; }

    public UserState State { get; set; }

    public Task Tell(ICommunication communication, string message, CancellationToken ct)
    {
        return communication.Tell(new CommunicationMethod(ChatId, message), ct);
    }
}