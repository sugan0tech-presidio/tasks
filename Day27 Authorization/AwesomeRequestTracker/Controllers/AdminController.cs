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
    public async Task<ActionResult<Registry>> ActivateUser(int id)
    {
        try
        {
            return Ok(adminService.ActivateUser(id));
        }
        catch (UserNotRegisteredException e)
        {
            Console.WriteLine(e);
            return NotFound(e.Message);
        }
    }
    [HttpPut("Dactivate/{id}")]
    public async Task<ActionResult<Registry>> DeactivateUser(int id)
    {
        try
        {
            return Ok(adminService.DeactivateUser(id));
        }
        catch (UserNotRegisteredException e)
        {
            Console.WriteLine(e);
            return NotFound(e.Message);
        }
    }
}