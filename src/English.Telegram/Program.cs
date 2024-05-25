using English.Application.Communications;
using English.Application.Routes;
using English.Application.Routes.Onboarding;
using English.Store;
using English.Store.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using UI.Telegram.Bot.DataService;

namespace UI.Telegram.Bot;

public static class Program
{
    public static async Task Main()
    {
        using CancellationTokenSource cts = new();
        var di = BuildDiContainer();
        
        var tgBot = di.GetRequiredService<TelegramBotReceivingBackground>();
        await tgBot.Start(cts.Token);
        
        
        Console.ReadKey();
        await cts.CancelAsync();
    }

    private static ServiceProvider BuildDiContainer()
    {
        var services = new ServiceCollection();

        services.AddSingleton<ITelegramBotClient>(
            _ => new TelegramBotClient(Environment.GetEnvironmentVariable("TOKEN_TG")!));
        services.AddSingleton<ITelegramDataService, TelegramDataService>();
        services.AddSingleton<ITextMessageCommunication, TelegramTextMessageCommunication>();

        services.AddSingleton<ICommunicationFactory, CommunicationFactory>();
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IStore, Store>();
        
        services.AddSingleton<Onboarding>();
        services.AddSingleton<Router>();
        services.AddSingleton<TelegramBotReceivingBackground>();
        
        return services.BuildServiceProvider();
    }
}