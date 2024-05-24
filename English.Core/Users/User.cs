using English.Core.Communications;

namespace English.Core.Users;

public sealed class User(Guid userId, string name)
{
    public Guid UserId { get; } = userId;
    public string Name { get; } = name;

    public Task Tell<T>(ICommunication communication, CommunicationMethod communicationMethod)
    {
        return communication.Tell(communicationMethod);
    }
}