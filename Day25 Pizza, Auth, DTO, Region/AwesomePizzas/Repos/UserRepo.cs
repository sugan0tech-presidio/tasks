using AwesomePizzas.Contexts;
using AwesomePizzas.Models;

namespace AwesomePizzas.Repos;

public class UserRepo: BaseRepo<User>
{
    public UserRepo(AwesomePizzasContext context) : base(context)
    {
    }
}