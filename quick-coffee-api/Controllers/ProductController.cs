using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quick_coffee_api.Models;
using quick_coffee_api.Services.ProductService;
using AutoMapper;


namespace quick_coffee_api.Controllers;

[Microsoft.AspNetCore.Components.Route("api/products")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public ProductController(ProductRepository repository, IMapper mapper,  IConfiguration configuration)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _configuration = configuration;
    }
    
    [HttpGet("getAllProducts")]
    public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
    {
        var products = await _repository.GetAllProductsAsync();
        var productDto = _mapper.Map<List<ProductDto>>(products);

        return Ok(productDto);
    }

}