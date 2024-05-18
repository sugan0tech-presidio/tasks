using AwesomeRequestTracker.DTO;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Serivces;
using AwesomeRequestTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeRequestTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController(IBaseService<Employee> _employeeService, RequestSolutionService _requestSolutionService)
    : ControllerBase
{
    [HttpGet("{id}")]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        try
        {
            var employee = await _employeeService.GetById(id);
            return Ok(employee);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _employeeService.GetAll();
        return Ok(employees);
    }

    [HttpPost]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTO employeeDTO)
    {
        var employee = new Employee
        {
            Name = employeeDTO.Name,
            ContactNumber = employeeDTO.ContactNumber,
            Email = employeeDTO.Email,
            Address = employeeDTO.Address,
            Role = employeeDTO.Role
        };

        try
        {
            var createdEmployee = await _employeeService.Add(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, createdEmployee);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDTO)
    {
        var employee = new Employee
        {
            Id = id,
            Name = employeeDTO.Name,
            ContactNumber = employeeDTO.ContactNumber,
            Email = employeeDTO.Email,
            Address = employeeDTO.Address,
            Role = employeeDTO.Role
        };

        try
        {
            var updatedEmployee = await _employeeService.Update(employee);
            return Ok(updatedEmployee);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        try
        {
            await _employeeService.Delete(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    [Authorize(Policy = "EmployeePolicy")]
    public async Task<IActionResult> ProvideSolution(FeedbackDTO feedbackDto)
    {
        try
        {
            var feedback = ConvertToSolutionFeedback(feedbackDto);
            _requestSolutionService.AddFeedback(feedback);

            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    public static SolutionFeedback ConvertToSolutionFeedback(FeedbackDTO feedbackDTO)
    {
        return new SolutionFeedback
        {
            Rating = feedbackDTO.Rating,
            Remarks = feedbackDTO.Remarks,
            SolutionId = feedbackDTO.SolutionId,
            FeedbackBy = feedbackDTO.FeedbackBy,
            FeedbackDate = feedbackDTO.FeedbackDate
        };
    }
}