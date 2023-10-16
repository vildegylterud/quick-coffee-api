using quick_coffee_api.Entities;

namespace quick_coffee_api.Services.ProductService;

public class ProductRepository : IProductRepository
{
    public async Task<ProductDocument?> GetProductAsync(string productId)
    {
        return null; 
        
    }
}