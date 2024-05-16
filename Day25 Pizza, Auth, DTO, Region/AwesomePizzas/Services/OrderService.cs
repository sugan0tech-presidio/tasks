using AwesomePizzas.Models;
using AwesomePizzas.Repos;

namespace AwesomePizzas.Services;

public class OrderService: BaseService<Order>
{
    public OrderService(IBaseRepo<Order> repository) : base(repository)
    {
    }
}