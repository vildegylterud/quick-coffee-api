using quick_coffee_api.Features.Products;

namespace quick_coffee_api.DbContext;
using Microsoft.EntityFrameworkCore;

public class QuickCoffeeContext : DbContext
{
    public QuickCoffeeContext(DbContextOptions<QuickCoffeeContext> options)
        : base(options)
    {
    }
    
    public DbSet<ProductDocument> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasManualThroughput(600);
        
        //Products
        modelBuilder.Entity<ProductDocument>()
            .HasNoDiscriminator().Property(p => p.Pk).ToJsonProperty(nameof(ProductDocument.Pk).ToLower());
        modelBuilder.Entity<ProductDocument>()
            .HasNoDiscriminator().Property(p => p.Id).ToJsonProperty("id");
            //.HasNoDiscriminator().Property(p => p.Id).ToJsonProperty(nameof(ProductDocument.Id).ToLower());
        modelBuilder.Entity<ProductDocument>().HasPartitionKey(product => product.Pk)
            .ToContainer(nameof(Products));
        
        modelBuilder.HasDefaultContainer(nameof(Products));

    }
}