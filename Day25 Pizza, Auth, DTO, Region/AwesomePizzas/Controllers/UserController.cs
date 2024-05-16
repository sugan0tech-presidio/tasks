using AwesomePizzas.Services;
using Microsoft.AspNetCore.Mvc;

namespace AwesomePizzas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService UserService;

    public UserController(UserService userService)
    {
        UserService = userService;
    }
}