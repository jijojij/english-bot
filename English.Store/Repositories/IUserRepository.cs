using English.Core.Users;

namespace English.Store.Repositories;

public interface IUserRepository : IGeneralRepository<User>
{
    Task<User?> Get(string name);
}