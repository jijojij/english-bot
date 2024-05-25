using English.Application.Routes.Models;
using English.Application.Routes.Onboarding;

namespace English.Application.Routes;

public class Router(Onboarding.Onboarding onboarding)
{
    public async Task Route(WasAction wasAction, CancellationToken ct)
    {
        if (wasAction.MetaData.ActionType is not ActionType.Message)
            return;

        if (wasAction.Data.Contains("/register", StringComparison.InvariantCultureIgnoreCase))
        {
            var handShakeInfo = new HandShakeInfo(wasAction.MetaData.ChatId, wasAction.MetaData.UserName!);
            await onboarding.HandShake(handShakeInfo, ct);
        }
    }
}