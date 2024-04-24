namespace ECommerceApp.Entities;

public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public User user { get; set; }
    public DateTime CreatedAt { get; set; }
    public double price { get; set; }
}