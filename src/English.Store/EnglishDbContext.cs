using English.Store.Models;
using Microsoft.EntityFrameworkCore;

namespace English.Store;

public class EnglishDbContext(DbContextOptions<EnglishDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<LearningPoint> LearningPoints { get; set; }
}