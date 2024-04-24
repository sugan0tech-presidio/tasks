using ECommerceApp.Entities;
using ECommerceApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Test.Repositories
{
    public class ProductRepositoryTest
    {
        private ProductRepository _productRepository;

        [SetUp]
        public void Setup()
        {
            // Initialize the repository before each test
            _productRepository = new ProductRepository();
        }

        [Test]
        public void AddProduct_ValidProduct_SavesProduct()
        {
            // Arrange
            Product product = new Product("oil", 12, 12);

            // Act
            _productRepository.Add(product);

            // Assert
            Assert.That(_productRepository.GetById(1), Is.EqualTo(product));
        }

        [Test]
        public void AddProduct_NullProduct_ThrowsArgumentNullException()
        {
            // Arrange
            Product product = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _productRepository.Add(product));
        }

        [Test]
        public void GetAllProduct_ValidProduct_RetunsAllProduct()
        {
            // Arrange
            Product product1 = new Product("oil", 12, 12);
            Product product2 = new Product("oil", 12, 12);

            // Act
            _productRepository.Add(product1);
            _productRepository.Add(product2);

            // Assert
            Assert.That(_productRepository.GetAll().Count, Is.EqualTo(2));
        }

        [Test]
        public void GetById_NonExistingId_ThrowsKeyNotFoundException()
        {
            // Arrange
            var nonExistingId = 999;

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _productRepository.GetById(nonExistingId));
        }

        [Test]
        public void UpdateProduct_ExistingProduct_ShowsUpdatedProduct()
        {
            // Arrange
            var product = new Product
            {
                Id = 123, // Assuming this ID doesn't exist in the repository
                Name = "Test Product",
                Price = 10.99,
                // Set other required properties
            };

            // Act
            _productRepository.Add(product);
            var updatedProduct = product;
            updatedProduct.Id = 1;
            updatedProduct.Name = "new name";
            _productRepository.Update(updatedProduct);

            // Assert
            Assert.That(_productRepository.GetById(updatedProduct.Id).Name, Is.EqualTo("new name"));
        }

        [Test]
        public void UpdateProduct_NonExistingProduct_ThrowsKeyNotFoundException()
        {
            // Arrange
            var product = new Product
            {
                Id = 123, // Assuming this ID doesn't exist in the repository
                Name = "Test Product",
                Price = 10.99,
                // Set other required properties
            };

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _productRepository.Update(product));
        }

        [Test]
        public void DeleteProduct_ExistingId_ThrowsKeyNotFoundException()
        {
            // Arrange
            var product = new Product
            {
                Id = 123, // Assuming this ID doesn't exist in the repository
                Name = "Test Product",
                Price = 10.99,
                // Set other required properties
            };
            _productRepository.Add(product);

            // Act & Assert
            _productRepository.Delete(1);
            Assert.That(_productRepository.GetAll().Count, Is.EqualTo(0));
        }

        [Test]
        public void DeleteProduct_NonExistingId_ThrowsKeyNotFoundException()
        {
            // Arrange
            var nonExistingId = 999;

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _productRepository.Delete(nonExistingId));
        }
    }
}
