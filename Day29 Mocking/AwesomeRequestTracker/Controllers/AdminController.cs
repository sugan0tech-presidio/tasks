using System.Security.Claims;
using AwesomeRequestTracker.Exceptions;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Serivces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeRequestTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "AdminPolicy")]
public class AdminController(AdminService adminService): ControllerBase {
    
    [HttpPut("Activate/{id}")]
    [ProducesResponseType(typeof(Registry), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Registry>> ActivateUser(int id)
    {
        try
        {
            return Ok(adminService.ActivateUser(id));
        }
        catch (UserNotRegisteredException e)
        {
            return NotFound(new ErrorModel(404, e.Message));
        }
        catch (AlreadyWithChangeException e)
        {
            return BadRequest(new ErrorModel(400, e.Message));
        }
    }
    [HttpPut("Dactivate/{id}")]
    [ProducesResponseType(typeof(Registry), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Registry>> DeactivateUser(int id)
    {
        try
        {
            return Ok(adminService.DeactivateUser(id));
        }
        catch (UserNotRegisteredException e)
        {
            return NotFound(new ErrorModel(404, e.Message));
        }
        catch (AlreadyWithChangeException e)
        {
            return BadRequest(new ErrorModel(400, e.Message));
        }
    }
}