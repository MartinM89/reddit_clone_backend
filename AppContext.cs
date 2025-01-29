using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<SubReddit> SubReddits { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DatabaseHelper.GetString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).HasColumnName("Id");
            entity.HasOne(p => p.User).WithMany(u => u.Posts);
            entity.HasOne(p => p.SubReddit).WithMany(sr => sr.Posts);
            entity.HasMany(p => p.Comments).WithOne(c => c.Post);
        });

        modelBuilder.Entity<SubReddit>(entity =>
        {
            entity.HasKey(sr => sr.Name);
            entity.Property(sr => sr.Name).HasColumnName("Name");
            entity.HasMany(sr => sr.Posts).WithOne(p => p.SubReddit);
            entity.HasMany(sr => sr.Users).WithMany(u => u.SubReddits);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("Id");
            entity.HasMany(u => u.Posts).WithOne(p => p.User);
            entity.HasMany(u => u.SubReddits).WithMany(sr => sr.Users);
            entity.HasMany(u => u.Comments).WithOne(c => c.User);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnName("Id");
            entity.HasOne(c => c.User).WithMany(u => u.Comments);
            entity.HasOne(c => c.Post).WithMany(p => p.Comments);
        });
    }
}
