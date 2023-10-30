using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using quick_coffee_api.DbContext;
using quick_coffee_api.Features.ExtraProducts.Models;
using quick_coffee_api.Features.Products.Models;

namespace quick_coffee_api.Features.Products;

public class ProductService : IProductService
{
    private readonly QuickCoffeeContext _context;

    public ProductService(QuickCoffeeContext context)

    {
        _context = context;
    }
    
    public async Task<List<ProductDocument>> GetAllProducts()
    {
        try
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
            
        }
        
    }
    
    public async Task<ProductDocument> GetProduct(Guid productId)
    {
        try
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == productId);
            return product;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;   
        }
        
    }
    

    public async Task CreateProduct(ProductDocument product)
    {
        try
        {
            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        
    }

    public async Task<ProductDocument> UpdateProduct(ProductDocument product)
    {
        try
        {
            var existingProduct = await GetProduct(product.Id.Value);
            if (existingProduct == null)
            {
                throw new Exception("The products data is null");
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.ProductTypeId = product.ProductTypeId;
            existingProduct.Description = product.Description;
            existingProduct.ExtraProducts = product.ExtraProducts;
            await _context.SaveChangesAsync();
            return existingProduct;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null; 
        }
        
    }
    
    public async Task DeleteProduct(Guid productId)
    {
        try
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
       
    }
    
}