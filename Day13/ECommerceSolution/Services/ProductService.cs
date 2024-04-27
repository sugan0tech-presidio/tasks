using ECommerceApp.Entities;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services;

public class ProductService : BaseService<Product>
{
    public ProductService(BaseRepository<Product> repository) : base(repository)
    {
    }
}