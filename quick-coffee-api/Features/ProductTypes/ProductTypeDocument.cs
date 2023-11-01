using System.ComponentModel.DataAnnotations;

namespace quick_coffee_api.Features.ProductTypes;

public class ProductTypeDocument
{
    public Guid? Pk
    {
        get => Id;
        set => Id = value;
    }
    [Key]
    public Guid? Id { get; set; }
    public string Name { get; set; }
  
}