using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quick_coffee_api.Features.ExtraProducts;
using quick_coffee_api.Features.Products.Models;

namespace quick_coffee_api.Features.Products;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;


    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProducts();
        return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
    }
    
    [HttpGet]
    [Route("{productId}")]
    public async Task<IActionResult> GetProduct(Guid productId)
    {
        var product = await _productService.GetProduct(productId);
        return Ok(_mapper.Map<ProductDto>(product));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductDto productDto)
    {
        try
        {
            var product = _mapper.Map<ProductDocument>(productDto);
            await _productService.CreateProduct(product);
            return Ok(product);

        }
        catch(Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    [Route("{productId}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        await _productService.DeleteProduct(productId);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(ProductDto productDto)
    {
        try
        {
            var product = _mapper.Map<ProductDocument>(productDto);
            
            var updatedProduct = await _productService.UpdateProduct(product);
            return Ok(_mapper.Map<ProductDto>(updatedProduct));
        }
        catch(Exception e)
        {
            return StatusCode(500, e.Message);
        } 
    }
}


