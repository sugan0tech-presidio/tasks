using AwesomePizzas.Contexts;
using AwesomePizzas.Models;

namespace AwesomePizzas.Repos;

public class OrderRepo : BaseRepo<Order>
{
    public OrderRepo(AwesomePizzasContext context) : base(context)
    {
    }
}