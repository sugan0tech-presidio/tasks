namespace ECommerceApp.Entities;

/// <summary>
///  Product Entity.
/// </summary>
public class Product : BaseEntity
{
    public Product()
    {
    }

    /// <summary>
    ///  Recommended constructor for Product.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="stock">Amount of stock available for that product</param>
    /// <param name="price">Price.</param>
    public Product(string name, int stock, double price)
    {
        Name = name;
        Stock = stock;
        Price = price;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Brand { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
    public int Discout { get; set; }

    public override bool Equals(object? obj)
    {
        var item = obj as Product;
        return item != null && base.Equals(obj) && Equals(item);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Category, Brand);
    }

    public bool Equals(Product obj)
    {
        return Name.Equals(obj.Name) && Category.Equals(obj.Category) && Brand.Equals(obj.Brand);
    }

    public override string ToString()
    {
        return $"User\t: {Id}" +
               $"\n\tName\t: {Name}" +
               $"\n\tCategory\t: {Category}" +
               $"\n\tStock\t: {Stock}" +
               $"\n\tPrice\t: ${Price}";
    }
}