using English.App.Action;
using English.Core.Communications;

namespace English.App.CommunicationWay;

public class CommunicationWayFactory(ITgDataService tgDataService)
{
    public ICommunication GetCommunicationWay(App app, ActionType actionType)
    {
        return app switch
        {
            App.Telegram => new TextMessageCommunication(tgDataService),
            _ => throw new ArgumentOutOfRangeException(nameof(app), app, null)
        };
    }
}

public enum App
{
    Telegram
}