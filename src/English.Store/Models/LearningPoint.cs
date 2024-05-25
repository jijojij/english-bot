using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace English.Store.Models;

[UsedImplicitly]
public class LearningPoint
{
    [Key]
    public Guid Id { get; set; }
    
    public required User User { get; set; }

    [StringLength(maximumLength: 512)]
    public required string LearningPointValue { get; set; }
    
    public required DateTime CreatedAtUtc { get; set; }
}