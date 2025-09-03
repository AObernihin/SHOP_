using Microsoft.EntityFrameworkCore;
using SHOP_.Models;

namespace SHOP_
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(c =>
            {
                c.HasKey(c => c.Id);
                c.Property(c => c.Name).IsRequired().HasMaxLength(50);

            });

            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(p => p.Id);
                p.Property(p => p.Name).IsRequired().HasMaxLength(50);
                p.Property(p => p.Price).HasDefaultValue(0);
                p.Property(p => p.Description).IsRequired().HasMaxLength(500);
                p.Property(p => p.Amount).IsRequired().HasDefaultValue(0);

                p.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
                
            });
        }








    }
}
