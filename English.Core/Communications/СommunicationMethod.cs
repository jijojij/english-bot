namespace English.Core.Communications;

public class CommunicationMethod(long destinationId, string message)
{
    public long DestinationId { get; } = destinationId;
    public string Message { get; } = message;
}