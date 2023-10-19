using Microsoft.AspNetCore.Mvc;
using quick_coffee_api.Features;
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
    
}