using Microsoft.EntityFrameworkCore;
using Project_l01.Api.Data.Seed;
using Project_l01.Api.Models;

namespace Project_l01.Api.Data;

public class ApplicationDbContext : DbContext
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly
        );

        modelBuilder.Entity<Category>()
            .HasData(CategorySeed.Data);

        modelBuilder.Entity<Product>()
            .HasData(ProductSeed.Data);

        modelBuilder.Entity<Customer>()
            .HasData(CustomerSeed.Data);

        modelBuilder.Entity<Order>()
            .HasData(OrderSeed.Data);

        modelBuilder.Entity<OrderItem>()
            .HasData(OrderItemSeed.Data);

    }
}