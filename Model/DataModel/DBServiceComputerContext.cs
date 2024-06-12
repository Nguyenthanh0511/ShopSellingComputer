using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace ServiceComputer.Model.DataModel
{
    public class DBServiceComputerContext : DbContext
    {
        public DBServiceComputerContext(DbContextOptions<DBServiceComputerContext> options)
            : base(options)
        {
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(p => new
            {
                p.Id,
            });

            modelBuilder.Entity<Product>().HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Image>().HasKey(I => new
            {
                I.Id,
            });

            modelBuilder.Entity<Image>().HasOne(p => p.Product)
                .WithMany(I => I.Images)
                .HasForeignKey(IP => IP.ProductId);
           

            modelBuilder.Entity<Order>().HasKey(p => new
            {
                p.Id,
            });

            modelBuilder.Entity<Order>().HasOne(c => c.User)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.UserId);
            //Shopcart
            modelBuilder.Entity<ShopCart>().HasOne(c => c.Products)
              .WithMany(p => p.ShopCarts)
              .HasForeignKey(p => p.productid);

            modelBuilder.Entity<ShopCart>().HasKey(p => new
            {
                p.Id,
            });
            modelBuilder.Entity<ShopCart>()
           .Property(p => p.total)
           .HasColumnType("decimal(18,2)");
        }
    }
}
