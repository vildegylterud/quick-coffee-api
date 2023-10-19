using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quick_coffee_api.DbContext;

namespace quick_coffee_api.Features.Products;

public class ProductService : IProductService
{
    private readonly IDbContextFactory<QuickCoffeeContext> _contextFactory;

    public ProductService(IDbContextFactory<QuickCoffeeContext> contextFactory)
    {
        _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }
    public async Task<List<ProductDocument>> GetAllProductsAsync()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Products.ToListAsync();
    }
}