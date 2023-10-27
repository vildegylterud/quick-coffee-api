using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using quick_coffee_api.Features.Products;
using quick_coffee_api.Features.ProductTypes.Models;


namespace quick_coffee_api.Features.ProductTypes;


[Route("api/productTypes")]
[ApiController]
public class ProductTypesController : ControllerBase
{
    private readonly IProductTypeService _productTypeService;
    private readonly IMapper _mapper;


    public ProductTypesController(IProductTypeService productTypeService, IMapper mapper)
    {
        _productTypeService = productTypeService ?? throw new ArgumentNullException(nameof(productTypeService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var productTypes = await _productTypeService.GetAllProductTypes();
        return Ok(_mapper.Map<IEnumerable<ProductTypeDto>>(productTypes));
    }

    
    [HttpPost]
    public async Task<IActionResult> CreateProductType(ProductTypeDto productTypeDto)
    {
        try
        {
            var productType = _mapper.Map<ProductTypeDocument>(productTypeDto);
            
            await _productTypeService.CreateProductType(productType);
            return Ok(productType);
            //Todo check if product exist?
        }
        catch(Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    
}