using English.App;
using English.Store;
using Telegram.Bot;
using UI.Telegram.Bot.TelegramBotDataService;

namespace UI.Telegram.Bot;

public class Program
{
    public static async Task Main(string[] args)
    {
        using CancellationTokenSource cts = new();
        
        var botClient = new TelegramBotClient(Environment.GetEnvironmentVariable("TOKEN_TG")!);
        var dataService = new TgDataService(botClient);
        var store = new Store();
        var @catch = new Catch(dataService, store);

        await dataService.StartReceiving(
            async action =>
            {
                await @catch.CatchMessage(action, cts.Token);
            }, cts.Token);

        Console.ReadKey();

    }
}