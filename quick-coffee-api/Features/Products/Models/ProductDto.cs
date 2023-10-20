using quick_coffee_api.Features.ExtraProducts;

namespace quick_coffee_api.Models;

public class ProductDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string ImgUrl { get; set; }
    public string ProductType { get; set; }
    
    public List<ExtraProductDocument> ExtraProduct { get; set; }
        = new List<ExtraProductDocument>();
}