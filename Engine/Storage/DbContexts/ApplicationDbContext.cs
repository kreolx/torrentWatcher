using Engine.Storage.Entities;
using Engine.Storage.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Engine.Storage.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Post> Posts { get; set; } = default!;
    public DbSet<FeedSettings> FeedSettings { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PostCfg());
        modelBuilder.ApplyConfiguration(new FeedSettingsCfg());
    }
}