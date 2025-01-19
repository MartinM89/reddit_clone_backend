using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    public DbSet<User> Users { get; set; }

    // public DbSet<Product> Products { get; set; }
    // public DbSet<Cart> Carts { get; set; }
    // public DbSet<ProductCart> ProductCarts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DatabaseHelper.GetString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Email);
            entity.Property(u => u.Email).HasColumnName("Email");
        });

        // modelBuilder.Entity<Product>(entity =>
        // {
        //     entity.HasKey(p => p.Id);
        //     entity.Property(p => p.Id).HasColumnName("Id");
        // });

        // modelBuilder.Entity<Cart>(entity =>
        // {
        //     entity.HasKey(c => c.Email);
        //     entity.Property(c => c.Email).HasColumnName("Email");
        //     entity.HasOne(c => c.User).WithMany(u => u.Carts).HasForeignKey(c => c.EmailFK);
        // });

        // modelBuilder.Entity<ProductCart>(entity =>
        // {
        //     entity.HasKey(pc => new { pc.CartEmail, pc.ProductId });
        //     entity.Property(pc => pc.CartEmail).HasColumnName("CartEmail");
        //     entity.Property(pc => pc.ProductId).HasColumnName("ProductId");
        //     entity
        //         .HasOne(pc => pc.Cart)
        //         .WithMany(c => c.ProductCarts)
        //         .HasForeignKey(pc => pc.CartEmail);
        //     entity
        //         .HasOne(pc => pc.Product)
        //         .WithMany(p => p.ProductCarts)
        //         .HasForeignKey(pc => pc.ProductId);
        // });
    }
}
