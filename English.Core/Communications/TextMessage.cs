namespace English.Core.Communications;

public class TextMessage(long destinationId, string message) : CommunicationMethod(destinationId, message);