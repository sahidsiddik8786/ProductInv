using Microsoft.EntityFrameworkCore;
using ProductInventoryAPI.Models;

namespace ProductInventoryAPI.Database
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<SubVariant> SubVariants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Variant>().HasKey(v => v.Id);
            modelBuilder.Entity<SubVariant>().HasKey(sv => sv.Id);

            modelBuilder.Entity<Variant>()
                .HasOne(v => v.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(v => v.ProductId);

            modelBuilder.Entity<SubVariant>()
                .HasOne(sv => sv.Variant)
                .WithMany(v => v.SubVariants)
                .HasForeignKey(sv => sv.VariantId);
        }
    }
}
