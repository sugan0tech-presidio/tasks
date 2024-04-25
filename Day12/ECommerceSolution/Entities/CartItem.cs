using ECommerceApp.Exceptions;

namespace ECommerceApp.Entities;

/// <summary>
/// A item to be stored within in cart.
/// </summary>
public class CartItem : BaseEntity
{
    public CartItem()
    {
        CreatedAt = DateTime.Now;
    }

    /// <summary>
    ///  Recommended Constructor
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="quantity">Quantity</param>
    /// <param name="user">User</param>
    /// <exception cref="TooMuchItemsException">If the required quantity is more  than the recommended max of 5</exception>
    public CartItem(Product product, int quantity, User user)
    {
        if (quantity > 5)
            throw new TooMuchItemsException($"Product: {product.Name} quantity should not be greater than 5");

        Product = product;
        Quantity = quantity;
        User = user;
        CreatedAt = DateTime.Now;
        Price = Product.Price * quantity;
    }

    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public User User { get; }
    public DateTime CreatedAt { get; private set; }
    public double Price { get; private set; }

    /// <summary>
    ///  Updates products with quantity.
    /// </summary>
    /// <param name="product"></param>
    /// <param name="quantity"></param>
    /// <exception cref="TooMuchItemsException">If the required quantity is more  than the recommended max of 5</exception>
    public void updateItems(Product product, int quantity)
    {
        if (quantity > 5)
            throw new TooMuchItemsException($"Product: {product.Name} quantity should not be greater than 5");

        Product = product;
        CreatedAt = DateTime.Now;
        Quantity = quantity;
        Price = Product.Price * quantity;
    }

    public override string ToString()
    {
        return $"Cart Item\t: {Id}" +
               $"\n\tFor User\t: {User.Name}" +
               $"\n\tProduct\t: {Product.Name}" +
               $"\n\tQuantity\t: {Quantity}" +
               $"\n\tPrice\t: ${Price}";
    }
}