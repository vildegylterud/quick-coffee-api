using Microsoft.EntityFrameworkCore;
using quick_coffee_api.DbContext;

namespace quick_coffee_api.Features.ProductTypes;

public class ProductTypeService : IProductTypeService
{
    private readonly QuickCoffeeContext _context;

    public ProductTypeService(QuickCoffeeContext context)

    {
        _context = context;
    }
    
    public async Task<List<ProductTypeDocument>> GetAllProductTypes()
    {
        var productTypes = await _context.ProductTypes.ToListAsync();
        return productTypes;
    }
    
    public async Task CreateProductType(ProductTypeDocument productType)
    {
        productType.Id = Guid.NewGuid();
        _context.ProductTypes.Add(productType);
        await _context.SaveChangesAsync();
    }
}