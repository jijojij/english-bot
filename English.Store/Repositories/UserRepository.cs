using System.Text.Json;
using English.Core.Users;

namespace English.Store.Repositories;

public class UserRepository : IUserRepository
{
    private const string Path = "users";

    public async Task<User[]> GetAll()
    {
        return await FileContext.GetContext<User>(Path);
    }

    public async Task<User?> Get(Guid userId)
    {
        var users = await GetAll();
        return users.FirstOrDefault(user => user.UserId == userId);
    }

    public Task<User?> GetUser(string userName)
    {
        throw new NotImplementedException();
    }

    public async Task Add(User user)
    {
        var users = await GetAll();
        if (users.Any(u => u.UserId == user.UserId || u.Name == user.Name))
        {
            return;
        }

        users = users.Append(user).ToArray();

        await FileContext.SaveContext(users, Path);
    }

    public async Task<User?> Get(string name)
    {
        var users = await GetAll();
        return users.FirstOrDefault(user => user.Name == name);
    }
}

public class FileContext
{
    public static async Task<T[]> GetContext<T>(string path)
    {
        var str = await File.ReadAllTextAsync($"database/{path}.json");
        return JsonSerializer.Deserialize<T[]>(str) ?? [];
    }

    public static async Task SaveContext<T>(T[] list, string path)
    {
        await File.WriteAllTextAsync($"database/{path}.json", JsonSerializer.Serialize(list));
    }
}