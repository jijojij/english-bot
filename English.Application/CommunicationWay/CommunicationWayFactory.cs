using English.Application.Action;
using English.Core.Communications;

namespace English.Application.CommunicationWay;

public class CommunicationWayFactory(ITextMessageCommunication textMessageCommunication)
{
    public ICommunication GetCommunicationWay(ActionType actionType)
    {
        return actionType switch
        {
            ActionType.Message => textMessageCommunication,
            _ => throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null)
        };
    }
}