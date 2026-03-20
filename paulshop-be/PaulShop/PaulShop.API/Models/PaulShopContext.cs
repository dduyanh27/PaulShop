using Microsoft.EntityFrameworkCore;

namespace PaulShop.API.Models
{
    public class PaulShopContext : DbContext
    {
        public PaulShopContext(DbContextOptions<PaulShopContext> options) : base(options)
        {
        }

        // Khai báo 3 bảng sẽ tạo trong SQL Server
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ràng buộc cho bảng Category
            modelBuilder.Entity<Category>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            // Ràng buộc cho bảng Product
            modelBuilder.Entity<Product>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");

                // Quan hệ 1 Category có nhiều Product
                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Ràng buộc cho bảng Account
            modelBuilder.Entity<Account>(entity => {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Email).IsUnique(); // Email không được trùng
            });
        }
    }
}