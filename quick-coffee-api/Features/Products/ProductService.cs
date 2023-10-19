using Microsoft.EntityFrameworkCore;
using quick_coffee_api.DbContext;
using quick_coffee_api.Entities;

namespace quick_coffee_api.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IDbContextFactory<QuickCoffeeContext> _contextFactory;

    public ProductService(IDbContextFactory<QuickCoffeeContext> contextFactory)
    {
        this._contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    public async Task<List<ProductDocument>> getAllProductsAsync()
    {
    }
    


}