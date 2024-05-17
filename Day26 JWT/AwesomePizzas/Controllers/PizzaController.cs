using AwesomePizzas.Exceptions;
using AwesomePizzas.Models;
using AwesomePizzas.Models.DTO;
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

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PizzaDTO>), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(ErrorModel))]
    public async Task<ActionResult<IEnumerable<PizzaDTO>>> GetAllPizzas()
    {
        try
        {
            var pizzas = await PizzaService.GetAll();

            return Ok(pizzas);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(ErrorModel))]
    public async Task<ActionResult<PizzaDTO>> GetPizzaById(int id)
    {
        try
        {
            var pizza = await PizzaService.GetById(id) ;

            return Ok(pizza);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new ErrorModel(StatusCodes.Status404NotFound, e.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}/stock")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(ErrorModel))]
    public async Task<ActionResult<int>> GetPizzaStock(int id)
    {
        try
        {
            var stock = await PizzaService.GetPizzaStock(id);

            return Ok(stock);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new ErrorModel(StatusCodes.Status404NotFound, e.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}