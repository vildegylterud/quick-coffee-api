using quick_coffee_api.DbContext;

namespace quick_coffee_api.Services.ProductService;

public class ProductService : IProductService
{
    private readonly QuickCoffeeContext _context;

    public ProductService(QuickCoffeeContext context)
    {
        _context = context;
    }
}