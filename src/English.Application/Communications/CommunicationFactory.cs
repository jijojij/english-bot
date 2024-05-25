using English.Application.Routes.Models;
using English.Core.Communications;

namespace English.Application.Communications;

public class CommunicationFactory(ITextMessageCommunication textMessageCommunication) : ICommunicationFactory
{
    public ICommunication CreateCommunication(ActionType actionType)
    {
        return actionType switch
        {
            ActionType.Message => textMessageCommunication,
            _ => throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null)
        };
    }
}