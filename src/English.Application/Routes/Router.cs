using English.Application.Routes.Models;
using English.Application.Routes.Onboarding;
using English.Application.StateManager;
using English.Core.Users;
using English.Store;
using English.Store.Models;

namespace English.Application.Routes;

public class Router(UserStateManager userStateManager,
    Onboarding.Onboarding onboarding,
    Ping.Ping ping)
{
    public async Task Route(WasAction wasAction, CancellationToken ct)
    {
        if (wasAction.MetaData.ActionType is not ActionType.Message)
            return;

        if (wasAction.Data.Contains("/register", StringComparison.InvariantCultureIgnoreCase))
        {
            var handShakeInfo = new HandShake(wasAction.MetaData.ChatId, wasAction.MetaData.UserName!);
            await onboarding.HandShake(handShakeInfo, ct);
            return;
        }

        
        var currentState = userStateManager.GetCurrentState(wasAction.MetaData.ChatId);
        if (currentState == UserState.Onboarding)
        {
            var niceToMeetYou = new NiceToMeetYou(
                wasAction.MetaData.ChatId, wasAction.MetaData.UserName!, wasAction.Data);
            await onboarding.NiceToMeetYou(niceToMeetYou, ct);
            return;
        }

        await ping.Pong(wasAction.MetaData.ChatId, ct);
    }
}