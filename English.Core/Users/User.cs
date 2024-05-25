﻿using English.Core.Communications;

namespace English.Core.Users;

public sealed class User(Guid userId, string name,  long chatId)
{
    public Guid UserId { get; } = userId;
    public string Name { get; } = name;
    public long ChatId { get; } = chatId;
    
    public Task Tell(ICommunication communication, string message)
    {
        return communication.Tell(new CommunicationMethod(ChatId, message));
    }
}