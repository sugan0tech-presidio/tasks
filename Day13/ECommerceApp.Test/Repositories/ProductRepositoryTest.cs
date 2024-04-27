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
            _productRepository = new ProductRepository();
        }

        [Test]
        public void AddProduct_ValidProduct_SavesProduct()
        {
            // Arrange
            Product product = new Product("oil", 12, 12);

            // Act
            _productRepository.AddAsync(product);

            // Assert
            Assert.That(_productRepository.GetByIdAsync(1).Result, Is.EqualTo(product));
        }

        [Test]
        public void AddProduct_NullProduct_ThrowsArgumentNullException()
        {
            // Arrange
            Product product = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _productRepository.AddAsync(product));
        }

        [Test]
        public void GetAllProduct_ValidProduct_RetunsAllProduct()
        {
            // Arrange
            Product product1 = new Product("oil", 12, 12);
            Product product2 = new Product("oil2", 12, 12);

            // Act
            _productRepository.AddAsync(product1);
            _productRepository.AddAsync(product2);

            // Assert
            Assert.That(_productRepository.GetAllAsync().Result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetById_NonExistingId_ThrowsKeyNotFoundException()
        {
            // Arrange
            var nonExistingId = 999;

            // Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => _productRepository.GetByIdAsync(nonExistingId));
        }

        [Test]
        public void UpdateProduct_ExistingProduct_ShowsUpdatedProduct()
        {
            // Arrange
            var product = new Product
            {
                Id = 123,
                Name = "Test Product",
                Price = 10.99,
                Category = "",
                Brand = ""
            };

            // Act
            _productRepository.AddAsync(product);
            var updatedProduct = product;
            updatedProduct.Id = 1;
            updatedProduct.Name = "new name";
            _productRepository.UpdateAsync(updatedProduct);

            // Assert
            Assert.That(_productRepository.GetByIdAsync(updatedProduct.Id).Result.Name, Is.EqualTo("new name"));
        }

        [Test]
        public void UpdateProduct_NonExistingProduct_ThrowsKeyNotFoundException()
        {
            // Arrange
            var product = new Product("test product", 2, 5);
            product.Brand = "";
            product.Category = "";
            product.Id = 1;

            // Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => _productRepository.UpdateAsync(product));
        }

        [Test]
        public void DeleteProduct_ExistingId_DeletesIt()
        {
            // Arrange
            var product = new Product("test product", 2, 5);
            product.Brand = "";
            product.Category = "";

            _productRepository.AddAsync(product);

            // Act & Assert
            _productRepository.DeleteAsync(1);
            Assert.That(_productRepository.GetAllAsync().Result.Count, Is.EqualTo(0));
        }

        [Test]
        public void DeleteProduct_NonExistingId_ThrowsKeyNotFoundException()
        {
            // Arrange
            var nonExistingId = 999;

            // Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => _productRepository.DeleteAsync(nonExistingId));
        }
    }
}