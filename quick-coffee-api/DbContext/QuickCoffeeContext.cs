using System.Net;
using Microsoft.Azure.Cosmos;
using quick_coffee_api.Entities;

namespace quick_coffee_api.DbContext;
using Microsoft.EntityFrameworkCore;

public class QuickCoffeeContext : DbContext
{
    public QuickCoffeeContext(DbContextOptions<QuickCoffeeContext> options)
        : base(options)
    {
    }
    public DbSet<ProductDocument> Products { get; set; }
    //public DbSet<ProductTypeDocument> ProductTypes { get; set; }
    //public DbSet<ExtraProductDocument> ExtraProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasManualThroughput(600);
        
        //Products
        modelBuilder.Entity<ProductDocument>()
            .HasNoDiscriminator()
            .ToContainer(nameof(Products))
            .HasPartitionKey(product => product.ProductType)
            .HasKey(product => new { product.Id });

        //ProductTypes
        
    }
    
    
}