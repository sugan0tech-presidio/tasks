using AwesomeRequestTracker.DTO;
using AwesomeRequestTracker.Exceptions;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Serivces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeRequestTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AuthService _authService, ILogger<AuthController> _logger) : ControllerBase
{
    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LoginReturnDTO>> Login([FromBody] LoginDTO loginDTO)
    {
        try
        {
            var loginReturnDTO = await _authService.Login(loginDTO);
            _logger.LogInformation(loginDTO.Email);
            _logger.LogCritical(loginDTO.Email);
            return Ok(loginReturnDTO);
        }
        catch (UserNotActivatedException e)
        {
            return BadRequest(new ErrorModel(404, e.Message));
        }
        catch (UserNotRegisteredException e)
        {
            return BadRequest(new ErrorModel(404, e.Message));
        }
        catch (AuthenticationException e)
        {
            return NotFound(new ErrorModel(404, e.Message));
        }
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
    {
        try
        {
            var success = await _authService.Register(registerDto);
            return Ok(new { Success = success });
        }
        catch (UserNotActivatedException e)
        {
            return BadRequest(new ErrorModel(404, e.Message));
        }
        catch (UserNotRegisteredException e)
        {
            return BadRequest(new ErrorModel(404, e.Message));
        }
        catch (AuthenticationException e)
        {
            return NotFound(new ErrorModel(404, e.Message));
        }
    }

    [HttpPost("ResetPassword")]
    [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
    {
        try
        {
            await _authService.ResetPassword(resetPasswordDTO);
            return Ok("Password reset successful");
        }
        catch (UserNotActivatedException e)
        {
            return BadRequest(new ErrorModel(400, e.Message));
        }
        catch (UserNotRegisteredException e)
        {
            return BadRequest(new ErrorModel(400, e.Message));
        }
        catch (AuthenticationException e)
        {
            return BadRequest(new ErrorModel(400,e.Message));
        }
    }
}