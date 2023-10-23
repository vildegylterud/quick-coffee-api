using System.ComponentModel.DataAnnotations;

namespace quick_coffee_api.Features.ExtraProducts;

public class ExtraProductDocument
{
    public Guid? Pk
    {
        get => Id;
        set => Id = value;
    }
    [Key]
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public int Quantity { get; set; }
}