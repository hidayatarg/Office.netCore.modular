using Microsoft.EntityFrameworkCore;
using Office.Core.Models;
using Office.Data.Configurations;
using Office.Data.Seeds;

namespace Office.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration Comes Here => Placed in Configuration
            // modelBuilder.Entity<Product>().Property(x => x.Id).UseIdentityColumn();
            // Since We Use Configurations
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
         
            // Apply Seeds
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] {1, 2}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] {1, 2}));

        }
    }
     
}