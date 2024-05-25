using System.ComponentModel.DataAnnotations;
using English.Core.Users;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace English.Store.Models;

[UsedImplicitly]
[Index(nameof(TelegramUserName), IsUnique = true)]
[Index(nameof(TelegramChatId), IsUnique = true)]
public class User
{
    [Key]
    public required Guid Id { get; set; }

    [CanBeNull]
    [StringLength(maximumLength: 512)]
    public string Name { get; set; }

    
    public required long TelegramChatId { get; set; }
    
    
    [StringLength(maximumLength: 512)]
    public required string TelegramUserName { get; set; }

    public required DateTime CreatedAtUtc { get; set; }
    
    public UserState State { get; set; } = UserState.Nothing;

    public ICollection<LearningPoint> LearningPoints { get; set; } = new List<LearningPoint>();
}