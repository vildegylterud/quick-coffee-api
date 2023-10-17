using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using quick_coffee_api.DbContexts;
using quick_coffee_api.Entities;

namespace quick_coffee_api.Services.ProductService;

public class ProductRepository : IProductRepository
{
    private readonly IDbContextFactory<QuickCoffeeContext> _contextFactory;
    
    public ProductRepository(IDbContextFactory<QuickCoffeeContext> contextFactory)
    {
        this._contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    
    public async Task<List<ProductDocument>> GetAllProductsAsync()
    {
        await using var queryContent = await _contextFactory.CreateDbContextAsync();
        var products = await queryContent.Products.ToListAsync();
        return products;
    }
}