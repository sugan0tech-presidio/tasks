using System.Security.Authentication;
using AwesomePizzas.Models;
using AwesomePizzas.Models.DTO;
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

    [HttpPost("login")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(ErrorModel))]
    public async Task<ActionResult<string>> Login([FromBody] LoginDTO userLogin)
    {
        try
        {
            var token = await UserService.Login(userLogin);

            return Ok(token);
        }
        catch (InvalidCredentialException e)
        {
            return Unauthorized(new ErrorModel(StatusCodes.Status401Unauthorized, e.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }


    [HttpPost("register")]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    [ProducesErrorResponseType(typeof(ErrorModel))]
    public async Task<ActionResult<string>> Register([FromBody] RegisterDTO userRegister)
    {
        try
        {
            var token = await UserService.Register(userRegister);

            return CreatedAtAction(nameof(Login), token);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}