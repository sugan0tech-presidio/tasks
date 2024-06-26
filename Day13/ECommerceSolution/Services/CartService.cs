﻿using ECommerceApp.Entities;
using ECommerceApp.Exceptions;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services;

public class CartService : BaseService<Cart>
{
    private ProductService ProductService;

    public CartService(BaseRepository<Cart> repository, ProductService productService) : base(repository)
    {
        ProductService = productService;
    }

    /// <summary>
    /// To add a product to cart, with quantity
    /// </summary>
    /// <param name="cartId">Cart Id</param>
    /// <param name="product">Product</param>
    /// <param name="quantity">Quantity</param>
    /// <exception cref="TooMuchItemsException">If product quantity exceeds it's stock count</exception>
    public async Task<Cart> AddItemToCart(int cartId, Product product, int quantity)
    {
        var cart = Repository.GetByIdAsync(cartId).Result;

        if (product.Stock < quantity)
        {
            throw new TooMuchItemsException("Provided quantity is higher than the actual stock");
        }


        var existingItem = cart.Items.FirstOrDefault(item => item.Product.Id == product.Id);
        if (existingItem != null)
        {
            if (existingItem.Quantity + quantity > 5)
                throw new TooMuchItemsException($"Product: {product.Name} quantity should not be greater than 5");
            
            existingItem.Quantity += quantity;
            cart.TotalPrice += product.Price * quantity;
        }
        else
        {
            var cartItem = new CartItem(product, quantity);
            cart.Items.Add(cartItem);
            cart.TotalPrice += product.Price * quantity;
        }

        await Repository.UpdateAsync(cart);
        product.Stock -= quantity;
        await ProductService.UpdateAsync(product);
        return cart;
    }

    /// <summary>
    /// Update existing cart
    /// </summary>
    /// <param name="cartId"></param>
    /// <param name="productId"></param>
    /// <param name="newQuantity"></param>
    /// <exception cref="TooMuchItemsException">If product quantity exceeds it's stock count</exception>
    /// <exception cref="CartItemNotFoundException">If updated cartite doesn't exixt</exception>
    public async Task<Cart> UpdateCartItemQuantity(int cartId, int productId, int newQuantity)
    {
        var cart = Repository.GetByIdAsync(cartId).Result;
        var product = ProductService.GetByIdAsync(productId).Result;
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
            cart.TotalPrice = product.Price * newQuantity;

            await ProductService.UpdateAsync(product);
            Repository.UpdateAsync(cart);
            return cart;
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
        var product = ProductService.GetByIdAsync(productId).Result;

        var cartItem = cart.Items.FirstOrDefault(item => item.Product.Id == productId);
        if (cartItem != null)
        {
            cart.Items.Remove(cartItem);
            product.Stock += cartItem.Quantity;
            cart.TotalPrice -= product.Price * cartItem.Quantity;

            await ProductService.UpdateAsync(product);
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
            ProductService.UpdateAsync(product);
        });
        await base.DeleteAsync(id);
    }
    
    
}