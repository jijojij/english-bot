using System.Text.Json;
using English.Core.Users;

namespace English.Store.Repositories;

public class UserRepository : IUserRepository
{
    private const string Path = "users";

    public async Task<User[]> GetAll(CancellationToken ct)
    {
        return await FileContext.GetContext<User>(Path, ct);
    }

    public async Task<User?> Get(Guid userId, CancellationToken ct)
    {
        var users = await GetAll(ct);
        return users.FirstOrDefault(user => user.UserId == userId);
    }

    public async Task Add(User user, CancellationToken ct)
    {
        var users = await GetAll(ct);
        if (users.Any(u => u.UserId == user.UserId || u.Name == user.Name))
        {
            return;
        }

        users = users.Append(user).ToArray();

        await FileContext.SaveContext(users, Path, ct);
    }

    public async Task<User?> Get(string name, CancellationToken ct)
    {
        var users = await GetAll(ct);
        return users.FirstOrDefault(user => user.Name == name);
    }
}

public class FileContext
{
    public static async Task<T[]> GetContext<T>(string path, CancellationToken ct)
    {
        var str = await File.ReadAllTextAsync($"database/{path}.json", ct);
        return JsonSerializer.Deserialize<T[]>(str) ?? [];
    }

    public static async Task SaveContext<T>(T[] list, string path, CancellationToken ct)
    {
        await File.WriteAllTextAsync($"database/{path}.json", JsonSerializer.Serialize(list), ct);
    }
}