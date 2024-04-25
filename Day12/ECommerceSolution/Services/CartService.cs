using ECommerceApp.Entities;
using ECommerceApp.Exceptions;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services;

public class CartService: BaseService<Cart>
{
    private ProductRepository _productRepository;
    public CartService(BaseRepository<Cart> repository, ProductRepository productRepository) : base(repository)
    {
        _productRepository = productRepository;
    }
    
    public void AddItemToCart(int cartId, Product product, int quantity)
    {
        var cart = Repository.GetById(cartId);

        if (product.Stock < quantity)
        {
            throw new TooMuchItemsException("Provided quantity is higher than the actual stock");
        }

        // updates product stock
        product.Stock -= quantity;
        _productRepository.Update(product);

        // Check if the product is already in the cart, then updates the quantity
        var existingItem = cart.Items.FirstOrDefault(item => item.Product.Id == product.Id);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            var cartItem = new CartItem(product, quantity, cart.User);
            cart.Items.Add(cartItem);
        }
        
        
        Repository.Update(cart);
    }

    public void UpdateCartItemQuantity(int cartId, int productId, int newQuantity)
    {
        var cart = Repository.GetById(cartId);
        var product = _productRepository.GetById(productId);
        var cartItem = cart.Items.FirstOrDefault(item => item.Product.Id == productId);
        if (cartItem != null)
        {
            product.Stock += cartItem.Quantity;
            if (product.Stock < newQuantity)
            {
            throw new TooMuchItemsException("Provided quantity is higher than the actual stock");
            }

            product.Stock -= newQuantity;
            cartItem.Quantity = newQuantity;
            
            _productRepository.Update(product);
            Repository.Update(cart);
        }
        else
        {
            throw new CartItemNotFoundException("Item not found in cart.");
        }
    }

    public void RemoveItemFromCart(int cartId, int productId)
    {
        var cart = Repository.GetById(cartId);
        var product = _productRepository.GetById(productId);
        
        var cartItem = cart.Items.FirstOrDefault(item => item.Product.Id == productId);
        if (cartItem != null)
        {
            cart.Items.Remove(cartItem);
            product.Stock += cartItem.Quantity;
            
            _productRepository.Update(product);
            Repository.Update(cart);
        }
        else
        {
            throw new CartItemNotFoundException("Item not found in cart.");
        }
    }

    public override void Delete(int id)
    {
        var cart = GetById(id);
        cart.Items.ForEach(cartItem =>
        {
            var product = cartItem.Product;
            product.Stock += cartItem.Quantity;
            _productRepository.Update(product);
        });
        base.Delete(id);
    }
}