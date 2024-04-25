using ECommerceApp.Entities;
using ECommerceApp.Repositories;
using ECommerceApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Test.Services
{
    [TestFixture]
    public class UserServiceTest
    {
        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            _userService = new UserService(new UserRepository());
        }

        [Test]
        public void GetById_ValidId_ReturnsUser()
        {
            // Arrange
            int userId = 1;
            var user = new User("Test User", "test@mail.com", "addr");
            _userService.Add(user);

            // Act
            var result = _userService.GetById(userId);

            // Assert
            Assert.That(result, Is.EqualTo(result));
        }

        [Test]
        public void GetById_InvalidId_ThrowsKeyNotFoundException()
        {
            // Arrange
            int userId = 999;

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _userService.GetById(userId));
        }

        [Test]
        public void AddUser_ValidUser_AddsUser()
        {
            // Arrange
            var user = new User("Test User", "test@mail.com", "addr");
            var expectedUser = new User("Test User", "test@mail.com", "addr");
            expectedUser.Id = 1;

            // Act
            var result = _userService.Add(user);

            // Assert
            Assert.That(result, Is.EqualTo(expectedUser));
        }

        [Test]
        public void AddUser_NullUser_ThrowsArgumentNullException()
        {
            // Arrange
            User user = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _userService.Add(user));
        }

        // Add more tests to cover other scenarios such as GetAll, Update, and Delete methods

        [Test]
        public void UpdateUser_ValidUser_UpdatesUser()
        {
            // Arrange
            var user = new User("Test User", "test@mail.com", "addr");
            _userService.Add(user);

            // Act
            user.Id = 1;
            user.Name = "new name";
            var result = _userService.Update(user);

            // Assert
            Assert.That(result, Is.EqualTo(user));
        }

        [Test]
        public void UpdateUser_NonExistingUser_ThrowsKeyNotFoundException()
        {
            // Arrange
            var user = new User("Test User", "test@mail.com", "addr");

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _userService.Update(user));
        }

        [Test]
        public void DeleteUser_ValidId_DeletesUser()
        {
            // Arrange
            int userId = 1;
            var user = new User("Test User", "test@mail.com", "addr");
            _userService.Add(user);

            // Act
            _userService.Delete(userId);

            // Assert
            Assert.That(_userService.GetAll().Count, Is.EqualTo(0));
        }

        [Test]
        public void DeleteUser_NonExistingId_ThrowsKeyNotFoundException()
        {
            // Arrange
            int userId = 999;

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _userService.Delete(userId));
        }

        // Add more tests as needed to cover various scenarios and exceptions
    }
}
