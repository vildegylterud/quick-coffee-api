using quick_coffee_api.Entities;

namespace quick_coffee_api.Services.ProductService;

public interface IProductRepository
{
    Task<List<ProductDocument>> GetAllProductsAsync(); 
}