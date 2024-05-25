using English.Application.Communications;
using English.Application.Routes.Models;
using English.Core.Users;
using English.Store;

namespace English.Application.Routes.Onboaring;

public class Onboarding(IStore store, ICommunicationFactory communicationFactory)
{
    public async Task HandShake(HandShakeInfo handShakeInfo, CancellationToken ct)
    {
        var user = new User(Guid.NewGuid(), handShakeInfo.Name, handShakeInfo.ChatId);
        await store.UserRepository.Add(user, ct);

        var communication = communicationFactory.CreateCommunication(ActionType.Message);
        await user.Tell(communication, "Nice to meet you!", ct);
    }
}

