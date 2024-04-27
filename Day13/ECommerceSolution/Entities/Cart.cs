using ECommerceApp.Exceptions;

namespace ECommerceApp.Entities;

/// <summary>
///  Cart Entity.
/// </summary>
public class Cart : BaseEntity
{
    public Cart()
    {
        Items = new List<CartItem>();
        UpdatedDate = DateTime.Now;
        TotalPrice = 0;
    }

    public DateTime UpdatedDate { get; set; }
    public List<CartItem> Items { get; }
    public double TotalPrice { get; set; }

    public double Discount { get; set; } = 0;
    public double ShippingCharge { get; set; } = 0;

    /// <summary>
    ///  Adds item to the Cart
    /// </summary>
    /// <param name="cartItem">Required product in CartItem</param>
    public void AddItem(CartItem cartItem)
    {
        TotalPrice += cartItem.Price;
        Items.Add(cartItem);
    }

    /// <summary>
    ///  Removes particular Item from the cart.
    /// </summary>
    /// <param name="cartItem"></param>
    /// <exception cref="CartItemNotFoundException">If that item doesn't exist</exception>
    public void RemoveItem(CartItem cartItem)
    {
        if (!Items.Contains(cartItem))
        {
            throw new CartItemNotFoundException("provided cartItem is not found");
        }

        TotalPrice -= cartItem.Price;
        Items.Remove(cartItem);
    }

    public override string ToString()
    {
        var cartItems = "";
        Items.ForEach(item =>
        {
            cartItems += $"\n\t{item.Product.Name}\t\t{item.Quantity} x {item.Product.Price}";
        });
        var res = $"\nCart \t: {Id}" +
                  $"{cartItems}"+
                  $"\n\tTotal Items\t: {Items.Count}" +
                  $"\n\tPrice\t\t: ${TotalPrice}";
        if (ShippingCharge > 0)
        {
            return res + $"\n\tShipping Charge\t: ${ShippingCharge}" +
                   $"\n\tTotal\t\t: ${(TotalPrice + ShippingCharge):F2}\n";
        }

        if (Discount > 0)
        {
            return res + $"\n\tDiscount\t:-${Discount:F2}" +
                   $"\n\tTotal\t\t: ${(TotalPrice - Discount):F2}\n";
        }

        return res + "\n";
    }
}