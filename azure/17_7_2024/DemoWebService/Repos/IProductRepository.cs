using DemoWebService.Models;

namespace DemoWebService.Repos;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int productId);
}
