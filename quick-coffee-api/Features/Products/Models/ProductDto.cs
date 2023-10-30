using quick_coffee_api.Features.ExtraProducts;
using quick_coffee_api.Features.ExtraProducts.Models;
using quick_coffee_api.Features.ProductTypes.Models;

namespace quick_coffee_api.Features.Products.Models;

public class ProductDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid? ProductTypeId { get; set; }
    public List<ExtraProductDto> ExtraProducts { get; set; } = new();
}