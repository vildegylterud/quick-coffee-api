namespace quick_coffee_api.Features.ExtraProducts;

public class ExtraProductDocument
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    

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
        obj is ExtraProductDocument productTypeDocument && productTypeDocument.Id == Id;
}