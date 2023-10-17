using Microsoft.EntityFrameworkCore;
using quick_coffee_api.Entities;

namespace quick_coffee_api.DbContexts
{
    public class QuickCoffeeContext : DbContext
    {
        public DbSet<ProductDocument> Products { get; set; }
        
        public QuickCoffeeContext(DbContextOptions<QuickCoffeeContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasManualThroughput(600);
            
            modelBuilder.Entity<ProductDocument>()
                .HasNoDiscriminator().Property(p => p.ProductType).ToJsonProperty("ProductType");
            modelBuilder.Entity<ProductDocument>().HasPartitionKey(product => product.ProductType)
                .ToContainer("Products");
        }
    }
}


