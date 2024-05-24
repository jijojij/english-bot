using English.Core.Users;

namespace English.Store;

public interface IStore
{
    Task<User[]> GetUsers();
    Task<User?> GetUser(Guid userId);
    Task AddUser(User user);
}