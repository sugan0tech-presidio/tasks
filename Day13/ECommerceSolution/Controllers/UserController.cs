using ECommerceApp.Entities;
using ECommerceApp.Services;

namespace ECommerceApp.Controllers;

public class UserController: BaseController<User>
{
    public UserController(BaseService<User> entityService) : base(entityService)
    {
    }
}