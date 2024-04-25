using ECommerceApp.Entities;
using ECommerceApp.Exceptions;
using ECommerceApp.Repositories;
using ECommerceApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Test.Services
{
    public class BillServiceTest
    {
        private BillService billService;
        private UserService userService;
        private CartService cartservice;

        [SetUp]
        public void SetUp()
        {
            userService = new UserService(new UserRepository());
            cartservice = new CartService(new CartRepository());
            billService = new BillService(cartservice, userService);
        }

        [Test]
        public void CheckoutUser_ValidUser_ReturnsCartAndWithShippingChange()
        {
            // Arrange
            User user = new User("test name", "", "");
            Cart cart = new Cart(user);
            Product product = new Product("test", 5, 5); 
            CartItem cartItem = new CartItem();
            cartItem.updateItems(product, 5);

            // Act
            user.Cart = cart;
            cart.AddItem(cartItem);
            user = userService.Add(user);
            cartservice.Add(cart);
            var res = billService.CheckoutUser(user);

            // Assert
            Assert.IsNotNull(res);
            Assert.That(100, Is.EqualTo(res.ShippingCharge));
        }

        [Test]
        public void CheckoutUser_UserWithNoCart_ThrowsCartNotFoundException()
        {
            // Arrange
            User user = new User("test name", "", "");
            user = userService.Add(user);

            // Act & Assert
            Assert.Throws<CartNotFoundException>(() => billService.CheckoutUser(user));

        }

        [Test]
        public void CheckoutUser_ValidUserForOffer_AddsDiscount()
        {
            // Arrange
            User user = new User("test name", "", "");
            Cart cart = new Cart(user);
            Product product = new Product("test", 5, 500); 
            CartItem cartItem = new CartItem();
            // Condition item should be equal to 3 with the amount of 1500
            cartItem.updateItems(product, 3);

            // Act
            user.Cart = cart;
            cart.AddItem(cartItem);
            user = userService.Add(user);
            cartservice.Add(cart);
            var res = billService.CheckoutUser(user);

            // Assert
            Assert.That(res.Discount, Is.EqualTo(1500 * 0.05));
        }

    }
}
