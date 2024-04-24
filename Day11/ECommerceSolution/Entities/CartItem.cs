namespace ECommerceApp.Entities;

public class CartItem: BaseEntity
{
    public CartItem()
    {
        CreatedAt = DateTime.Now;
    }

    public CartItem(Product product, int quantity, User user, double price)
    {
        Product = product;
        Quantity = quantity;
        this.User = user;
        CreatedAt = DateTime.Now;
        this.Price = price;
    }
    
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public double Price { get; set; }

    public override string ToString()
    {
        return $"Cart Item\t: {Id}" +
               $"\n\tFor User\t: {User.Name}" +
               $"\n\tProduct\t: {Product.Name}" +
               $"\n\tQuantity\t: {Quantity}" +
               $"\n\tPrice\t: ${Price}";
    }
}