using AwesomePizzas.Services;
using Microsoft.AspNetCore.Mvc;

namespace AwesomePizzas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly PizzaService PizzaService;

    public PizzaController(PizzaService pizzaService)
    {
        PizzaService = pizzaService;
    }
}