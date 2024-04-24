namespace ECommerceApp.Entities;

public class Product: BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Brand { get; set; }
    public int stock { get; set; }
    public double Price { get; set; }
    public int discount { get; set; }
}