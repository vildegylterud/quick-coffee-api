namespace quick_coffee_api.Features.ExtraProducts;

public interface IExtraProductService
{
    Task CreateExtraProduct(ExtraProductDocument extraProduct);
    Task<List<ExtraProductDocument>> GetAllExtraProducts();
    Task<ExtraProductDocument> GetExtraProduct(Guid extraProductId);
    Task<ExtraProductDocument> UpdateExtraProduct(ExtraProductDocument extraProduct);
    Task DeleteExtraProduct(Guid extraProductId);
    
}