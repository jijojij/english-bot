using English.Application.Routes.Models;
using English.Core.Communications;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace UI.Telegram.Bot.DataService;

public class TelegramDataService(ITelegramBotClient innerClient) : ITelegramDataService
{
    # region private

    private TgWasAction? Handler { get; set; }

    private async Task InnerHandler(ITelegramBotClient _, Update update, CancellationToken ct)
    {
        if (Handler is null)
            throw new Exception("Handler is null");

        if (update.Message?.Text is not { } messageText)
            return;

        var was = new WasAction(
            new MetaData(update.Message.Chat.Id, ActionType.Message)
                { UserName = update.Message.From?.Username },
            messageText);

        await Handler(was, ct);
    }

    #endregion

    public Task StartReceiving(TgWasAction handler, CancellationToken ct)
    {
        Handler = handler;

        innerClient.StartReceiving(
            updateHandler: InnerHandler,
            pollingErrorHandler: (_, exception, _) =>
            {
                Console.WriteLine(exception.Message);
                return Task.CompletedTask;
            },
            receiverOptions: new ReceiverOptions { AllowedUpdates = [] },
            cancellationToken: ct
        );

        return Task.CompletedTask;
    }

    public async Task SendMessage(CommunicationMethod communication, CancellationToken ct)
    {
        await innerClient.SendTextMessageAsync(
            communication.ChatId, communication.Message, cancellationToken: ct);
    }
}