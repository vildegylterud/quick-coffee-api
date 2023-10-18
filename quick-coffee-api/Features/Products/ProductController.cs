using Microsoft.AspNetCore.Mvc;
using quick_coffee_api.Services.ProductService;
using quick_coffee_api.Models;

namespace quick_coffee_api.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("[controller]")]
public class ProductController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet("getAllProducts")]
    public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        var productDto = _productService.Map<List<ProductDto>>(products);

        return Ok(productDto);
    }
}