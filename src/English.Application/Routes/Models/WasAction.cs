namespace English.Application.Routes.Models;

public class WasAction(MetaData metaData, string data)
{
    public MetaData MetaData { get; } = metaData;

    public string Data { get; } = data;
}