using AwesomePizzas.Services;
using Microsoft.AspNetCore.Mvc;

namespace AwesomePizzas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderService OrderService;

    public OrderController(OrderService orderService)
    {
        OrderService = orderService;
    }
}