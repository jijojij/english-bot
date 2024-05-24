namespace English.Core;

public interface IDestinationId<out T>
{
    public T Value { get; }
}
