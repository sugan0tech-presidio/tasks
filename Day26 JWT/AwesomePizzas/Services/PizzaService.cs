using AwesomePizzas.Models;
using AwesomePizzas.Repos;

namespace AwesomePizzas.Services;

public class PizzaService : BaseService<Pizza>
{
    public PizzaService(IBaseRepo<Pizza> repository) : base(repository)
    {
    }

    public async Task<int> GetPizzaStock(int id)
    {
        return GetById(id).Result.Stock;
    }
}