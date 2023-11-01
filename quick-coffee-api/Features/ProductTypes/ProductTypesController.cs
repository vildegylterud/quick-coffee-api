using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using quick_coffee_api.Features.Products;
using quick_coffee_api.Features.ProductTypes.Models;


namespace quick_coffee_api.Features.ProductTypes;


[Route("api/producttypes")]
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
    public async Task<IActionResult> GetAllProductTypes()
    {
        var productTypes = await _productTypeService.GetAllProductTypes();
        return Ok(_mapper.Map<IEnumerable<ProductTypeDto>>(productTypes));
    }

    [HttpGet]
        [Route("{productTypeId}")]
        public async Task<IActionResult> GetProductType(Guid productTypeId)
        {
            var productType = await _productTypeService.GetProductType(productTypeId);
            return Ok(_mapper.Map<ProductTypeDto>(productType));
        }
        
    
    
    [HttpPost]
    public async Task<IActionResult> CreateProductType(ProductTypeDto productTypeDto)
    {
        try
        {
            var productType = _mapper.Map<ProductTypeDocument>(productTypeDto);
            await _productTypeService.CreateProductType(productType);
            return Ok(productType);

        }
        catch(Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    [Route("{productTypeId}")]
    public async Task<IActionResult> DeleteProductType(Guid productTypeId)
    {
        await _productTypeService.DeleteProductType(productTypeId);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductType(ProductTypeDto productTypeDto)
    {
        try
        {
            var productType = _mapper.Map<ProductTypeDocument>(productTypeDto);
            
            var updatedProductType = await _productTypeService.UpdateProductType(productType);
            return Ok(_mapper.Map<ProductTypeDto>(updatedProductType));
        }
        catch(Exception e)
        {
            return StatusCode(500, e.Message);
        } 
    }
}



    
    
