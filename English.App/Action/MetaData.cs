namespace English.App.Action;

public class MetaData(long chatId, ActionType actionType)
{
    public long ChatId { get; } = chatId;
    public ActionType ActionType { get;  } = actionType;
    
    
    public string? UserName { get; set; }
}