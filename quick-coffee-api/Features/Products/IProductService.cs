using quick_coffee_api.Entities;

namespace quick_coffee_api.Services.ProductService;

public interface IProductService
{

    public Task<List<ProductDocument>> getAllProductsAsync();
}