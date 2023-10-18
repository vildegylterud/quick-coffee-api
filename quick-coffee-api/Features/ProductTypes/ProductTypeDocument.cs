namespace quick_coffee_api.Features.ProductTypes;

public class ProductTypeDocument
{
    public string Id { get; set; }
    public string CategoryName { get; set; }
    public string ImgUrl { get; set; }
    

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
    public override bool Equals(object obj) =>
        obj is ProductTypeDocument productTypeDocument && productTypeDocument.Id == Id;

}