using System.ComponentModel.DataAnnotations;

namespace quick_coffee_api.Entities;

public class ProductDocument
{
    public string ProductType
    {
        get { return Id; }
        set { Id = value; }
    }
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double? Price { get; set; }
    public string ProductTypeReference { get; set; }
}
