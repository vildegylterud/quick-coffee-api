using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using quick_coffee_api.Features.ExtraProducts;
using quick_coffee_api.Features.ProductTypes;

namespace quick_coffee_api.Features.Products;
public class ProductDocument
{
    public Guid? Pk
    {
        get => Id;
        set => Id = value;
    }
    [Key]
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public Guid? ProductTypeId { get; set; }
    public List<ExtraProductDocument> ExtraProducts { get; set; } = new ();
}