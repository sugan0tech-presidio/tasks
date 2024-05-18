using AwesomeRequestTracker.DTO;
using AwesomeRequestTracker.Exceptions;
using AwesomeRequestTracker.Serivces;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeRequestTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AuthService _authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        try
        {
            var loginReturnDTO = await _authService.Login(loginDTO);
            return Ok(loginReturnDTO);
        }
        catch (AuthenticationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
    {
        try
        {
            var success = await _authService.Register(registerDto);
            return Ok(new { Success = success });
        }
        catch (AuthenticationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
    {
        try
        {
            await _authService.ResetPassword(resetPasswordDTO);
            return Ok("Password reset successful");
        }
        catch (AuthenticationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}