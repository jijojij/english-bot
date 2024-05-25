using English.Store.Repositories;

namespace English.Store;

public class Store(IUserRepository userRepository) : IStore
{
    public IUserRepository UserRepository { get; } = userRepository;
}

public interface IStore
{
    public IUserRepository UserRepository { get; } 
}