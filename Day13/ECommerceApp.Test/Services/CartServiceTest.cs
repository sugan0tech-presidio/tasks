using ECommerceApp.Entities;
using ECommerceApp.Exceptions;
using ECommerceApp.Repositories;
using ECommerceApp.Services;

namespace ECommerceApp.Test.Services;

public class CartServiceTest
{
    private CartService _cartService;
    private ProductRepository _productRepository;
    private Cart _cart;
    private Product _product;

    [SetUp]
    public void Setup()
    {
        _productRepository = new ProductRepository();
        _cart = new Cart(new User("testUser", "mail", "addr"));
        _product = new Product("Test Product", 10, 20.0)
        {
            Brand = "test",
            Category = "cat"
        };
        _cartService = new CartService(new CartRepository(), _productRepository);
        _cartService.AddAsync(_cart);
        _product = _productRepository.Add(_product);
    }

    [Test]
    public void AddItemToCart_Successfully()
    {
        // Arrange
        int initialStock = _product.Stock;
        int quantityToAdd = 3;

        // Act
        _cartService.AddItemToCart(_cart.Id, _product, quantityToAdd);

        // Assert
        Assert.That(_product.Stock, Is.EqualTo(initialStock - quantityToAdd));
        Assert.That(_cart.Items.Count, Is.EqualTo(1));
        Assert.That(_cart.Items[0].Quantity, Is.EqualTo(quantityToAdd));
    }

    [Test]
    public void UpdateItemToCart_Successfully()
    {
        // Arrange
        int initialStock = _product.Stock;
        int quantityToAdd = 3;
        int updateQuantity = 2;

        // Act
        _cartService.AddItemToCart(_cart.Id, _product, quantityToAdd);

        _cartService.AddItemToCart(_cart.Id, _product, updateQuantity);

        // Assert
        Assert.That(_product.Stock, Is.EqualTo(initialStock - (quantityToAdd + updateQuantity)));
        Assert.That(_cart.Items.Count, Is.EqualTo(1));
        Assert.That(_cart.Items[0].Quantity, Is.EqualTo(quantityToAdd + updateQuantity));
    }

    [Test]
    public void AddItemToCart_QuantityGreaterThanStock_ThrowsTooMuchItemsException()
    {
        // Arrange
        int quantityToAdd = 15;

        // Act & Assert
        Assert.Throws<TooMuchItemsException>(() => _cartService.AddItemToCart(_cart.Id, _product, quantityToAdd));
    }

    [Test]
    public void UpdateCartItemQuantity_Successfully()
    {
        // Arrange
        int initialStock = _product.Stock;
        int initialQuantity = 2;
        int newQuantity = 5;
        _cart.Items.Add(new CartItem(_product, initialQuantity, _cart.User));

        // Act
        _cartService.UpdateCartItemQuantity(_cart.Id, _product.Id, newQuantity);

        // Assert
        Assert.That(_product.Stock, Is.EqualTo(initialStock - (newQuantity - initialQuantity)));
        Assert.That(_cart.Items.Count, Is.EqualTo(1));
        Assert.That(_cart.Items[0].Quantity, Is.EqualTo(newQuantity));
    }

    [Test]
    public void UpdateCartItemQuantity_QuantityGreaterThanStock_ThrowsTooMuchItemsException()
    {
        // Arrange
        int initialQuantity = 2;
        _cart.Items.Add(new CartItem(_product, initialQuantity, _cart.User));
        int newQuantity = 15;

        // Act & Assert
        Assert.Throws<TooMuchItemsException>(() =>
            _cartService.UpdateCartItemQuantity(_cart.Id, _product.Id, newQuantity));
    }

    [Test]
    public void UpdateCartItemQuantity_InvalidCartItem_ThrowsCartItemNotFoundException()
    {
        // Arrange
        int newQuantity = 15;

        // Act & Assert
        Assert.Throws<CartItemNotFoundException>(() =>
            _cartService.UpdateCartItemQuantity(_cart.Id, _product.Id, newQuantity));
    }

    [Test]
    public void RemoveItemFromCart_Successfully()
    {
        // Arrange
        int initialStock = _product.Stock;
        int initialQuantity = 3;
        _cart.Items.Add(new CartItem(_product, initialQuantity, _cart.User));

        // Act
        _cartService.RemoveItemFromCart(_cart.Id, _product.Id);

        // Assert
        Assert.That(_product.Stock, Is.EqualTo(initialStock + initialQuantity));
        Assert.That(_cart.Items.Count, Is.EqualTo(0));
    }

    [Test]
    public void RemoveItemFromCart_ItemNotFound_ThrowsCartItemNotFoundException()
    {
        // Arrange
        var product2 = new Product
        {
            Name = "product 2",
            Brand = "brand2",
            Category = "cat2",
            Price = 12,
            Stock = 5
        };
        _productRepository.Add(product2);

        // Act & Assert
        Assert.Throws<CartItemNotFoundException>(() => _cartService.RemoveItemFromCart(_cart.Id, 2));
    }

    [Test]
    public void DeleteCart_ValidUpdatesProductStock_Success()
    {
        // Arrange
        int initialStock = _product.Stock;
        int quantityToAdd = 3;

        // Act
        _cartService.AddItemToCart(_cart.Id, _product, quantityToAdd);
        _cartService.DeleteAsync(1);
        _product = _productRepository.GetById(1);

        // Assert
        Assert.That(_product.Stock, Is.EqualTo(initialStock));
    }
}