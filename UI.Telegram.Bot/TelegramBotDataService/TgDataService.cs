using English.App;
using English.App.Action;
using English.Core.Communications;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace UI.Telegram.Bot.TelegramBotDataService;

public class TgDataService(ITelegramBotClient innerClient) : ITgDataService
{
    # region private
    
    private TgWasAction? Handler { get; set; }
    private Task InnerHandler(ITelegramBotClient _, Update update, CancellationToken __)
    {
        if (Handler is null)
            throw new Exception("Handler is null");
        
        if (update.Message?.Text is not { } messageText)
            return Task.CompletedTask;

        Handler(new WasAction(new MetaData(update.Message.Chat.Id, ActionType.Message)
        {
            UserName = update.Message.From?.Username
        }, messageText));
        return Task.CompletedTask;
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
            communication.DestinationId, communication.Message, cancellationToken: ct);
    }
}