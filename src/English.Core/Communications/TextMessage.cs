namespace English.Core.Communications;

public class TextMessage(long chatId, string message) : CommunicationMethod(chatId, message);