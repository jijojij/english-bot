using System.Text.Json;
using English.Core.Users;

namespace English.Store;

public class Store
{
    public async Task<User[]> GetUsers()
    {
        var json = await File.ReadAllTextAsync("database/users.json");
        var users = JsonSerializer.Deserialize<User[]>(json);
        return users ?? [];
    }

    public async Task<User?> GetUser(Guid userId)
    {
        var users = await GetUsers();
        return users.FirstOrDefault(user => user.UserId == userId);
    }
    
    public async Task AddUser(User user)
    {
        var users = await GetUsers();
        if (users.Any(u => u.UserId == user.UserId))
        {
            return;
        }
        
        users = users.Append(user).ToArray();
        var json = JsonSerializer.Serialize(users);
        await File.WriteAllTextAsync("database/users.json", json);
    }
}