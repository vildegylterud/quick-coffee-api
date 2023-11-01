
using quick_coffee_api.Features.Products.Models;

namespace quick_coffee_api.Features.Products;


public interface IProductService
{
    Task<List<ProductDocument>> GetAllProducts(); 
    Task<ProductDocument> GetProduct(Guid productId);
    Task CreateProduct(ProductDocument product);
    Task DeleteProduct(Guid productId);
    Task<ProductDocument> UpdateProduct(ProductDocument product);
}