using AwesomePizzas.Models;
using AwesomePizzas.Repos;

namespace AwesomePizzas.Services;

public class UserService : BaseService<User>
{
    public UserService(IBaseRepo<User> repository) : base(repository)
    {
    }
}