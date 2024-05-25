namespace English.Store;

public interface IGeneralRepository<T>
{
    Task<T[]> GetAll();
    Task<T?> Get(Guid _);
    Task Add(T _);     
}