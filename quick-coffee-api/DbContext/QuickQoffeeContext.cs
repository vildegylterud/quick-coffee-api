using System.Net;
using Microsoft.Azure.Cosmos;
using quick_coffee_api.Entities;

namespace quick_coffee_api.DbContext;
using Microsoft.EntityFrameworkCore;

public class QuickQoffeeContext : DbContext
{
    
    
    /// <summary>
    /// Gets or sets the products collection.
    /// </summary>
    public DbSet<ProductDocument> Products { get; set; }
    
}