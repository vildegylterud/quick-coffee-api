using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quick_coffee_api.DbContext;
using quick_coffee_api.Features;
using quick_coffee_api.Services.ProductService;
using quick_coffee_api.Models;


namespace quick_coffee_api.Controllers;

[Microsoft.AspNetCore.Components.Route("api/products")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService _productService)
    {
        _productService = _productService ?? throw new ArgumentNullException(nameof(_productService));
;
    }
    
    [HttpGet("getAllProducts")]
    public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return products; 
    }
    


