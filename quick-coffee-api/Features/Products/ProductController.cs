using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quick_coffee_api.Entities;

namespace quick_coffee_api.Features.Products;

[Microsoft.AspNetCore.Components.Route("api/products")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        ;
    }

    [HttpGet("getAllProducts")]
    public async Task<List<ProductDocument>> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return products;
    }

}


