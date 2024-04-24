using ECommerceApp.Entities;
using ECommerceApp.Exceptions;

namespace ECommerceApp.Services;

/// <summary>
/// Processes User Bills with discount & Shipment charge.
/// Bill be used as Cart
/// </summary>
public class BillService
{
    private readonly CartService _cartService;
    private readonly UserService _userService;

    public BillService(CartService cartService, UserService userService)
    {
        _cartService = cartService;
        _userService = userService;
    }

    /// <summary>
    ///  Process users cart
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    /// <exception cref="CartNotFoundException">If the User don't have any cart associated with them</exception>
    public  Cart CheckoutUser(User user)
    {
        if (user.Cart == null)
            throw new CartNotFoundException($"User {user.Name} doesn't have a cart");
        
        user.Cart = CheckoutCartPrice(user.Cart);
        _userService.Update(user);
        return user.Cart;
    }

    /// <summary>
    ///  Adds cart with shipping charge & discount;
    /// </summary>
    /// <param name="cart"></param>
    /// <returns></returns>
    public Cart CheckoutCartPrice(Cart cart)
    {
        if (cart.TotalPrice < 100)
        {
            cart.ShippingCharge = 100;
        }

        int totalItems = 0;
        cart.Items.ForEach(card => { totalItems += card.Quantity; });
        if (totalItems.Equals(3) && cart.TotalPrice.Equals(1500))
        {
            cart.Discount = 1500 * 0.05;
        }

        _cartService.Update(cart);
        
        return cart;
    }
}