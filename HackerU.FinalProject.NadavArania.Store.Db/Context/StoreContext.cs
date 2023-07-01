using HackerU.FinalProject.NadavArania.Store.Db.Models;
using HackerU.FinalProject.NadavArania.Store.Db.PreConfig;
using Microsoft.EntityFrameworkCore;

namespace HackerU.FinalProject.NadavArania.Store.Db.Context
{
    public class StoreContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrdersProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=LAPTOP-LCMU98BH;Database=StoreDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersConfig());
            modelBuilder.ApplyConfiguration(new ProductsConfig());
            modelBuilder.ApplyConfiguration(new OrdersConfig());
            modelBuilder.ApplyConfiguration(new OrdersProductsConfig());
            modelBuilder.Entity<Order>()
        .HasMany(x => x.Products)
        .WithMany(x => x.Orders)
        .UsingEntity<OrderProduct>(
            c => c.HasOne(x => x.Product)
                  .WithMany()
                  .HasForeignKey(x => x.ProductId),
            c => c.HasOne(c => c.Order)
                  .WithMany()
                  .HasForeignKey(c => c.OrderId)
                  );
        }
    }
}
