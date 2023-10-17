namespace quick_coffee_api.Models;

public class ProductDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double? Price { get; set; }
    public string ProductTypeReference { get; set; }
}

