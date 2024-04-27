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
    
    /// <summary>
    /// To add a product to cart, with quantity
    /// </summary>
    /// <param name="cartId">Cart Id</param>
    /// <param name="product">Product</param>
    /// <param name="quantity">Quantity</param>
    /// <exception cref="TooMuchItemsException">If product quantity exceeds it's stock count</exception>
    public void AddItemToCart(int cartId, Product product, int quantity)
    {
        var cart = Repository.GetById(cartId);

        if (product.Stock < quantity)
        {
            throw new TooMuchItemsException("Provided quantity is higher than the actual stock");
        }

        product.Stock -= quantity;
        _productRepository.Update(product);

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

    /// <summary>
    /// Update existing cart
    /// </summary>
    /// <param name="cartId"></param>
    /// <param name="productId"></param>
    /// <param name="newQuantity"></param>
    /// <exception cref="TooMuchItemsException">If product quantity exceeds it's stock count</exception>
    /// <exception cref="CartItemNotFoundException">If updated cartite doesn't exixt</exception>
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

    /// <summary>
    /// Remove a item from cart
    /// </summary>
    /// <param name="cartId"></param>
    /// <param name="productId"></param>
    /// <exception cref="CartItemNotFoundException"></exception>
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
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