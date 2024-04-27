using ECommerceApp.Entities;
using ECommerceApp.Services;

namespace ECommerceApp.Controllers;

public class CartController: BaseController<Cart>
{
    public CartController(BaseService<Cart> entityService) : base(entityService)
    {
    }
}