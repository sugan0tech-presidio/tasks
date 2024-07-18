using DemoWebService.Models;

namespace DemoWebService.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int productId);
}
