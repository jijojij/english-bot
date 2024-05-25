using English.Application.Routes.Models;
using English.Core.Communications;

namespace English.Application.Communications;

public interface ICommunicationFactory
{
    ICommunication CreateCommunication(ActionType actionType);
}