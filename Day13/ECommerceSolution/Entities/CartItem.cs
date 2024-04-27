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
    public CartItem(Product product, int quantity)
    {
        if (quantity > 5)
            throw new TooMuchItemsException($"Product: {product.Name} quantity should not be greater than 5");

        Product = product;
        Quantity = quantity;
        CreatedAt = DateTime.Now;
        Price = Product.Price * quantity;
    }

    public Product Product { get; private set; }
    public int Quantity { get; set; }
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
        return $"Item\t: " +
               $"\n\tProduct\t: {Product.Name}" +
               $"\n\tQuantity\t: {Quantity}" +
               $"\t\tPrice\t: ${Price}";
    }
}