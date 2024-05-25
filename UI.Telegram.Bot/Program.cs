using English.App;
using English.Store;
using English.Store.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using UI.Telegram.Bot.TelegramBotDataService;

namespace UI.Telegram.Bot;

public class Program
{
    public static async Task Main()
    {
        using CancellationTokenSource cts = new();

        var di = BuildDiContainer();

        var dataService = di.GetRequiredService<ITgDataService>();
        var @catch = di.GetRequiredService<Catch>();

        await dataService.StartReceiving(
            async action => { await @catch.CatchMessage(action, cts.Token); }, cts.Token);


        Console.WriteLine("Press any key to exit");
        Console.ReadKey();

        await cts.CancelAsync();
    }

    private static ServiceProvider BuildDiContainer()
    {
        var services = new ServiceCollection();

        services.AddSingleton<ITelegramBotClient>(
            _ => new TelegramBotClient(Environment.GetEnvironmentVariable("TOKEN_TG")!));
        services.AddSingleton<ITgDataService, TgDataService>();

        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IStore, Store>();
        services.AddSingleton<Catch>();
        return services.BuildServiceProvider();
    }
}