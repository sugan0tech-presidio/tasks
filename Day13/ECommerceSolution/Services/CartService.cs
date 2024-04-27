using ECommerceApp.Entities;
using ECommerceApp.Exceptions;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services;

public class CartService : BaseService<Cart>
{
    private ProductRepository _productRepository;

    public CartService(BaseRepository<Cart> repository, ProductRepository productRepository) : base(repository)
    {
        _productRepository = productRepository;
    }

    /// <summary>
    /// To add a product to cart, with quantity
    /// </summary>
    /// <param name="cartId">Cart Id</param>
    /// <param name="product">Product</param>
    /// <param name="quantity">Quantity</param>
    /// <exception cref="TooMuchItemsException">If product quantity exceeds it's stock count</exception>
    public async Task AddItemToCart(int cartId, Product product, int quantity)
    {
        var cart = Repository.GetByIdAsync(cartId).Result;

        if (product.Stock < quantity)
        {
            throw new TooMuchItemsException("Provided quantity is higher than the actual stock");
        }

        product.Stock -= quantity;
        _productRepository.UpdateAsync(product);

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

        await Repository.UpdateAsync(cart);
    }

    /// <summary>
    /// Update existing cart
    /// </summary>
    /// <param name="cartId"></param>
    /// <param name="productId"></param>
    /// <param name="newQuantity"></param>
    /// <exception cref="TooMuchItemsException">If product quantity exceeds it's stock count</exception>
    /// <exception cref="CartItemNotFoundException">If updated cartite doesn't exixt</exception>
    public async Task UpdateCartItemQuantity(int cartId, int productId, int newQuantity)
    {
        var cart = Repository.GetByIdAsync(cartId).Result;
        var product = _productRepository.GetByIdAsync(productId).Result;
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

            await _productRepository.UpdateAsync(product);
            Repository.UpdateAsync(cart);
        }
        else
        {
            throw new CartItemNotFoundException("Item not found in cart.");
        }
    }

    /// <summary>
    /// Remove a item from cart
    /// </summary>
    /// <param name="cartId"></param>
    /// <param name="productId"></param>
    /// <exception cref="CartItemNotFoundException"></exception>
    public async Task RemoveItemFromCart(int cartId, int productId)
    {
        var cart = Repository.GetByIdAsync(cartId).Result;
        var product = _productRepository.GetByIdAsync(productId).Result;

        var cartItem = cart.Items.FirstOrDefault(item => item.Product.Id == productId);
        if (cartItem != null)
        {
            cart.Items.Remove(cartItem);
            product.Stock += cartItem.Quantity;

            await _productRepository.UpdateAsync(product);
            Repository.UpdateAsync(cart);
        }
        else
        {
            throw new CartItemNotFoundException("Item not found in cart.");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    public override async Task DeleteAsync(int id)
    {
        var cart = GetByIdAsync(id).Result;
        cart.Items.ForEach(cartItem =>
        {
            var product = cartItem.Product;
            product.Stock += cartItem.Quantity;
            _productRepository.UpdateAsync(product);
        });
        await base.DeleteAsync(id);
    }
    
    
}