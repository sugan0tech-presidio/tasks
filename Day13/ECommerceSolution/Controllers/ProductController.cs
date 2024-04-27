using ECommerceApp.Entities;
using ECommerceApp.Services;

namespace ECommerceApp.Controllers;

public class ProductController: BaseController<Product>
{
    public ProductController(BaseService<Product> entityService) : base(entityService)
    {
    }
}