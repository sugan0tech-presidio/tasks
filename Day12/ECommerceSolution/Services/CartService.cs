using ECommerceApp.Entities;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services;

public class CartService: BaseService<Cart>
{
    public CartService(BaseRepository<Cart> repository) : base(repository)
    {
    }
    
    public void AddItemToCart(int cartId, Product product, int quantity)
    {
        var cart = Repository.GetById(cartId);

        // Check if the product is already in the cart
        var existingItem = cart.Items.FirstOrDefault(item => item.Product.Id == product.Id);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            var cartItem = new CartItem(product, 4, cart.User);
            cart.Items.Add(cartItem);
        }
        
        
        Repository.Update(cart);
    }

    public void UpdateCartItemQuantity(int cartId, int productId, int newQuantity)
    {
        var cart = Repository.GetById(cartId);
        var cartItem = cart.Items.FirstOrDefault(item => item.Product.Id == productId);
        if (cartItem != null)
        {
            cartItem.Quantity = newQuantity;
            Repository.Update(cart);
        }
        else
        {
            throw new ArgumentException("Item not found in cart.");
        }
    }

    public void RemoveItemFromCart(int cartId, int productId)
    {
        var cart = Repository.GetById(cartId);
        var cartItem = cart.Items.FirstOrDefault(item => item.Product.Id == productId);
        if (cartItem != null)
        {
            cart.Items.Remove(cartItem);
            Repository.Update(cart);
        }
        else
        {
            throw new ArgumentException("Item not found in cart.");
        }
    }

    public override Cart Update(Cart entity)
    {
        var id = entity.Id;
        var oldCart = Repository.GetById(id);
        return base.Update(entity);
    }

    public override void Delete(int id)
    {
        base.Delete(id);
    }
}