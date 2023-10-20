using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using quick_coffee_api.Features.ExtraProducts;

namespace quick_coffee_api.Features.Products;
public class ProductDocument
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string ImgUrl { get; set; }
    public string ProductType { get; set; }
    
    public List<ExtraProductDocument> ExtraProduct { get; set; }
        = new List<ExtraProductDocument>();
}