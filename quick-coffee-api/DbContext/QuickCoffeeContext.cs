using quick_coffee_api.Features.Products;
using quick_coffee_api.Features.ProductTypes;

namespace quick_coffee_api.DbContext;
using Microsoft.EntityFrameworkCore;

public class QuickCoffeeContext : DbContext
{
    public QuickCoffeeContext(DbContextOptions<QuickCoffeeContext> options)
        : base(options)
    {
    }
    
    public DbSet<ProductDocument> Products { get; set; } 
    public DbSet<ProductTypeDocument> ProductTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasManualThroughput(600);
        
        //Products
        modelBuilder.Entity<ProductDocument>()
            .HasNoDiscriminator().Property(p => p.Pk).ToJsonProperty(nameof(ProductDocument.Pk).ToLower());
        modelBuilder.Entity<ProductDocument>()
            .HasNoDiscriminator().Property(p => p.Id).ToJsonProperty("id");
        modelBuilder.Entity<ProductDocument>().HasPartitionKey(product => product.Pk)
            .ToContainer(nameof(Products));
        
        //ProductTypes
        modelBuilder.Entity<ProductTypeDocument>()
            .HasNoDiscriminator().Property(p => p.Pk).ToJsonProperty(nameof(ProductTypeDocument.Pk).ToLower());
        modelBuilder.Entity<ProductTypeDocument>()
            .HasNoDiscriminator().Property(p => p.Id).ToJsonProperty("id");
        modelBuilder.Entity<ProductTypeDocument>().HasPartitionKey(productType => productType.Pk)
            .ToContainer(nameof(ProductTypes));

        
        
        //modelBuilder.HasDefaultContainer(nameof(Products));

    }
}