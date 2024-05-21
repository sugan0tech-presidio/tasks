using AwesomeRequestTracker.Serivces;
using Microsoft.AspNetCore.Authorization;

namespace AwesomeRequestTracker.Controllers;

using Microsoft.AspNetCore.Mvc;
using DTO;
using Models;
using Services;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "UserPolicy")]
public class RequestController (RequestService _requestService, ITokenService _tokenService): ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<RequestDTO>> GetRequest(int id)
    {
        try
        {
            var request = await _requestService.GetById(id);
            return Ok(MapToDTO(request));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<RequestDTO>>> GetAllRequests()
    {
        var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault("");
        Console.WriteLine(token);
        var payload = _tokenService.GetPayload(token.Split(" ").LastOrDefault(""));
        var requests = await _requestService.GetAll(payload.Id, payload.Role);
        return Ok(requests.Select(MapToDTO).ToList());
    }

    [HttpPost]
    public async Task<ActionResult<RequestDTO>> CreateRequest(RequestDTO requestDto)
    {
        var request = MapToEntity(requestDto);
        var createdRequest = await _requestService.Add(request);
        return CreatedAtAction(nameof(GetRequest), new { id = createdRequest.Id }, MapToDTO(createdRequest));
    }

    [HttpPut]
    public async Task<ActionResult<RequestDTO>> UpdateRequest(RequestDTO requestDto)
    {
        try
        {
            var request = MapToEntity(requestDto);
            var updatedRequest = await _requestService.Update(request);
            return Ok(MapToDTO(updatedRequest));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRequest(int id)
    {
        try
        {
            await _requestService.Delete(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    private static RequestDTO MapToDTO(Request request)
    {
        Console.WriteLine(request.RequestMessage);
        return new RequestDTO
        (
            request.Id,
            request.RequestMessage,
            request.RequestDate,
            request.ClosedDate,
            request.RequestStatus,
            request.RequestRaisedById,
            request.RequestClosedBy
        );
    }

    private static Request MapToEntity(RequestDTO requestDto)
    {
        return new Request
        {
            RequestMessage = requestDto.RequestMessage,
            RequestDate = requestDto.RequestDate,
            ClosedDate = requestDto.ClosedDate,
            RequestStatus = requestDto.RequestStatus,
            RequestRaisedById = requestDto.RequestRaisedById,
            RequestClosedBy = requestDto.RequestClosedBy
        };
    }
}