using AwesomePizzas.Contexts;
using AwesomePizzas.Models;

namespace AwesomePizzas.Repos;

public class PizzaRepo : BaseRepo<Pizza>
{
    public PizzaRepo(AwesomePizzasContext context) : base(context)
    {
    }
}