namespace English.Core.Communications;

public class CommunicationMethod(long chatId, string message)
{
    public long ChatId { get; } = chatId;
    public string Message { get; } = message;
}