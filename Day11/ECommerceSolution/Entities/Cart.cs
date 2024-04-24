namespace ECommerceApp.Entities;

public class Cart
{
    public User user { get; set; }
    public DateTime UpdatedDate { get; set; }
    public List<CartItem> itmes { get; set; }
    public Product Product { get; set; }
    public double TotalPrice { get; set; }
}