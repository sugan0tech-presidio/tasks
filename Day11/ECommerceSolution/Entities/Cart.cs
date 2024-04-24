namespace ECommerceApp.Entities;

public class Cart: BaseEntity
{
    public Cart(User user)
    {
        User = user;
        Items = new List<CartItem>();
        UpdatedDate = DateTime.Now;
        TotalPrice = 0;
    }

    public User User { get; set; }
    public DateTime UpdatedDate { get; set; }
    public List<CartItem> Items { get; set; }
    public double TotalPrice { get; set; }
    
    public override string ToString()
    {
        return $"Cart \t: {Id}" +
               $"\n\tFor User\t: {User.Name}" +
               $"\n\tTotal Items\t: {Items.Count}" +
               $"\n\tPrice\t: ${TotalPrice}";
    }
}