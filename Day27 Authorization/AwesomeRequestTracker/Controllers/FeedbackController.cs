using Microsoft.AspNetCore.Mvc;
using AwesomeRequestTracker.DTO;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;
using Microsoft.AspNetCore.Authorization;

namespace AwesomeRequestTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "UserPolicy")]
public class FeedbackController : ControllerBase
{
    private readonly IBaseRepo<SolutionFeedback> _feedbackService;

    public FeedbackController(IBaseRepo<SolutionFeedback> feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FeedbackDTO>> GetFeedback(int id)
    {
        try
        {
            var feedback = await _feedbackService.GetById(id);
            return Ok(MapToDTO(feedback));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<FeedbackDTO>>> GetAllFeedbacks()
    {
        var feedbacks = await _feedbackService.GetAll();
        return Ok(feedbacks.Select(MapToDTO).ToList());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<FeedbackDTO>> UpdateFeedback(int id, FeedbackDTO feedbackDto)
    {
        if (id != feedbackDto.Id)
        {
            return BadRequest("Feedback ID mismatch");
        }

        try
        {
            var feedback = MapToEntity(feedbackDto);
            var updatedFeedback = await _feedbackService.Update(feedback);
            return Ok(MapToDTO(updatedFeedback));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeedback(int id)
    {
        try
        {
            await _feedbackService.DeleteById(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    private static FeedbackDTO MapToDTO(SolutionFeedback feedback)
    {
        return new FeedbackDTO(
            feedback.Id,
            feedback.Rating,
            feedback.Remarks,
            feedback.SolutionId,
            feedback.FeedbackBy);
    }

    private static SolutionFeedback MapToEntity(FeedbackDTO feedbackDto)
    {
        return new SolutionFeedback
        {
            Id = feedbackDto.Id,
            Rating = feedbackDto.Rating,
            Remarks = feedbackDto.Remarks,
            SolutionId = feedbackDto.SolutionId,
            FeedbackBy = feedbackDto.FeedbackBy,
            FeedbackDate = feedbackDto.FeedbackDate
        };
    }
}