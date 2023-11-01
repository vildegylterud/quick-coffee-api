namespace quick_coffee_api.Features.ProductTypes;

public interface IProductTypeService
{
    Task CreateProductType(ProductTypeDocument productType);
    Task<List<ProductTypeDocument>> GetAllProductTypes();
    Task<ProductTypeDocument> GetProductType(Guid productId);
    Task<ProductTypeDocument> UpdateProductType(ProductTypeDocument productType);
    Task DeleteProductType(Guid productTypeId);
}