
namespace quick_coffee_api.Features.Products;


public interface IProductService
{

    public Task<List<ProductDocument>> GetAllProductsAsync();
}