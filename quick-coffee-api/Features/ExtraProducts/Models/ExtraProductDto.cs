namespace quick_coffee_api.Features.ExtraProducts.Models;

public class ExtraProductDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public int Quantity { get; set; }
}