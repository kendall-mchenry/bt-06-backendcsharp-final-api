using final_api.Models;
using Microsoft.EntityFrameworkCore;

namespace final_api.Migrations;

public class PostsDbContext : DbContext 
{
    public DbSet<Post> Posts { get; set; }

    public DbSet<User> Users { get; set; }

    public PostsDbContext(DbContextOptions<PostsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Post>(entity => 
        {
            entity.HasKey(e => e.PostId);
            entity.HasOne(e => e.User).WithMany().IsRequired();
            entity.Property(e => e.Title);
            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.PostedDate);
        });
    
        // TO DO -- add User entity builder
    }
}