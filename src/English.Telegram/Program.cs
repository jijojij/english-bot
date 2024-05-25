using English.Application.Communications;
using English.Application.Routes;
using English.Application.Routes.Onboarding;
using English.Application.Routes.Ping;
using English.Application.StateManager;
using English.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using UI.Telegram.Bot.DataService;

namespace UI.Telegram.Bot;

public class Program : IDesignTimeDbContextFactory<EnglishDbContext>
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

        services.AddDbContext<EnglishDbContext>(
            opt =>
            {
                opt.UseMySql("Server=localhost;Database=english;User Id=root;Password=root", new MySqlServerVersion(new Version(8, 2, 0)));
            });

        services.AddSingleton<ITelegramBotClient>(
            _ => new TelegramBotClient(Environment.GetEnvironmentVariable("TOKEN_TG")!));
        services.AddSingleton<ITelegramDataService, TelegramDataService>();
        services.AddSingleton<ITextMessageCommunication, TelegramTextMessageCommunication>();

        services.AddSingleton<ICommunicationFactory, CommunicationFactory>(); ;

        services.AddSingleton<UserStateManager>();
        services.AddSingleton<Onboarding>();
        services.AddSingleton<Ping>();
        services.AddSingleton<Router>();
        services.AddSingleton<TelegramBotReceivingBackground>();

        return services.BuildServiceProvider();
    }

    public EnglishDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EnglishDbContext>();
        optionsBuilder.UseMySql(
            "Server=localhost;Database=english;User Id=root;Password=root",
            new MySqlServerVersion(new Version(8, 2, 0)));
        return new EnglishDbContext(optionsBuilder.Options);
    }
}