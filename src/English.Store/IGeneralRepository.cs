namespace English.Store;

public interface IGeneralRepository<T>
{
    Task<T[]> GetAll(CancellationToken ct);
    Task<T?> Get(Guid _, CancellationToken ct);
    Task Add(T _, CancellationToken ct);     
}