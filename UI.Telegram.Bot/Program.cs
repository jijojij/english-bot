using English.App;
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

        await dataService.StartReceiving(
            async action =>
            {
                await new Catch(dataService).CatchMessage(action, cts.Token);
            }, cts.Token);

        Console.ReadKey();

    }
}