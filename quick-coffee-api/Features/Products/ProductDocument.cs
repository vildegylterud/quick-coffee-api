using quick_coffee_api.Features.ExtraProducts;
using quick_coffee_api.Features.ProductTypes;

namespace quick_coffee_api.Entities;
public class ProductDocument
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string ImgUrl { get; set; }
    public ProductTypeDocument ProductType { get; set; }
    
    public List<ExtraProductDocument> ExtraProduct { get; set; }
        = new List<ExtraProductDocument>();

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>The hash code of the unique identifier.</returns>
    public override int GetHashCode() => Id.GetHashCode();

    /// <summary>
    /// Implements equality.
    /// </summary>
    /// <param name="obj">The object to compare to.</param>
    /// <returns>A value indicating whether the unique identifiers match.</returns>
    public override bool Equals(object? obj) =>
        obj is ProductDocument productDocument && productDocument.Id == Id;
    
}