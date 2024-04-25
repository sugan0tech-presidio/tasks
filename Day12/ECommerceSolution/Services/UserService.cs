using ECommerceApp.Entities;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services;

public class UserService: BaseService<User>
{
    public UserService(BaseRepository<User> repository) : base(repository)
    {
    }
}