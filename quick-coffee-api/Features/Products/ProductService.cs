using Microsoft.EntityFrameworkCore;
using quick_coffee_api.DbContext;
using quick_coffee_api.Features.ExtraProducts.Models;
using quick_coffee_api.Features.Products.Models;

namespace quick_coffee_api.Features.Products;

public class ProductService : IProductService
{
    private readonly QuickCoffeeContext _context;
    private readonly IDbContextFactory<QuickCoffeeContext> _contextFactory;

    //public ProductService(IDbContextFactory<QuickCoffeeContext> contextFactory)
    public ProductService(QuickCoffeeContext context)

    {
        _context = context;
        //_contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }
    
    public async Task<List<ProductDocument>> GetAllProducts()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }
    
    public async Task<ProductDocument> GetProduct(Guid productId)
    {
        var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == productId);
        return product;
    }
    

    public async Task CreateProduct(ProductDocument product)
    {
        product.Id = Guid.NewGuid();
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task<ProductDocument> UpdateProduct(ProductDocument product)
    {
        var existingProduct = await GetProduct(product.Id.Value);
        if (existingProduct == null)
        {
            return null;
        }
        
        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.ProductType = product.ProductType;
        existingProduct.Description = product.Description;
        existingProduct.ExtraProducts = product.ExtraProducts;
        await _context.SaveChangesAsync();
        return existingProduct;
    }
    
    public async Task DeleteProduct(Guid productId)
    {
        var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == productId);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
    
}