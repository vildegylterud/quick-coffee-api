using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using quick_coffee_api.DbContext;
using quick_coffee_api.Features.Products;

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
        try
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
            return productTypes;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null; 
        }
       
    }
    
    public async Task CreateProductType(ProductTypeDocument productType)
    {
        try
        {
            productType.Id = Guid.NewGuid();
                    _context.ProductTypes.Add(productType);
                    await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }
    
    public async Task<ProductTypeDocument> GetProductType(Guid productTypeId)
    {
        try
        {
            var productType = await _context.ProductTypes.FirstOrDefaultAsync(productType => productType.Id == productTypeId);
            return productType;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;   
        }
        
    }
    
    public async Task<ProductTypeDocument> UpdateProductType(ProductTypeDocument productType)
    {
        try
        {
            var existingProductType = await GetProductType(productType.Id.Value);
            if (existingProductType == null)
            {
                throw new Exception("The products data is null");
            }

            existingProductType.Name = productType.Name;
            
            await _context.SaveChangesAsync();
            return existingProductType;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null; 
        }
        
    }

    
    public async Task DeleteProductType(Guid productTypeId)
    {
        try
        {
            var productType = await _context.ProductTypes.FirstOrDefaultAsync(product => product.Id == productTypeId);
            if (productType != null)
            {
                _context.ProductTypes.Remove(productType);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
       
    }
}