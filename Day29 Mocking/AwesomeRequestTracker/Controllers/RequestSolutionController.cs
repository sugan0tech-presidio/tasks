using Microsoft.AspNetCore.Mvc;
using AwesomeRequestTracker.DTO;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Serivces;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "EmployeePolicy")]
public class RequestSolutionController : ControllerBase
{
    private readonly RequestSolutionService _solutionService;

    public RequestSolutionController(RequestSolutionService solutionService)
    {
        _solutionService = solutionService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SolutionDTO>> GetSolution(int id)
    {
        try
        {
            var solution = await _solutionService.GetById(id);
            return Ok(MapToDTO(solution));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<SolutionDTO>>> GetAllSolutions()
    {
        var solutions = await _solutionService.GetAll();
        return Ok(solutions.Select(MapToDTO).ToList());
    }

    [HttpPost]
    public async Task<ActionResult<SolutionDTO>> CreateSolution(SolutionDTO solutionDto)
    {
        var solution = MapToEntity(solutionDto);
        var createdSolution = await _solutionService.Add(solution);
        return Ok(MapToDTO(createdSolution));
    }

    [HttpPost("Feedback")]
    public async Task<ActionResult<RequestSolution>> AddFeedback(FeedbackDTO feedbackDto)
    {
        var feedback = MapToEntity(feedbackDto);
        var updatedSolution = await _solutionService.AddFeedback(feedback);
        return Ok(updatedSolution);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SolutionDTO>> UpdateSolution(int id, SolutionDTO solutionDto)
    {
        if (id != solutionDto.RequestId)
        {
            return BadRequest("Solution ID mismatch");
        }

        try
        {
            var solution = MapToEntity(solutionDto);
            var updatedSolution = await _solutionService.Update(solution);
            return Ok(MapToDTO(updatedSolution));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSolution(int id)
    {
        try
        {
            await _solutionService.Delete(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    private static SolutionDTO MapToDTO(RequestSolution solution)
    {
        return new SolutionDTO(
            solution.RequestId,
            solution.SolutionDescription,
            solution.SolvedBy,
            solution.IsSolved,
            solution.RequestRaiserComment);
    }

    private static RequestSolution MapToEntity(SolutionDTO solutionDto)
    {
        return new RequestSolution
        {
            RequestId = solutionDto.RequestId,
            SolutionDescription = solutionDto.SolutionDescription,
            SolvedBy = solutionDto.SolvedBy,
            SolvedDate = solutionDto.SolvedDate,
            IsSolved = solutionDto.IsSolved,
            RequestRaiserComment = solutionDto.RequestRaiserComment
        };
    }

    private static SolutionFeedback MapToEntity(FeedbackDTO solutionDto)
    {
        return new SolutionFeedback
        {
            Rating = solutionDto.Rating,
            Remarks = solutionDto.Remarks,
            SolutionId = solutionDto.SolutionId,
            FeedbackBy = solutionDto.FeedbackBy
        };
    }
}