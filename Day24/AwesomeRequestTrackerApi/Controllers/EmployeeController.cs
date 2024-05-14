using AwesomeRequestTrackerApi.Exeptions;
using AwesomeRequestTrackerApi.Models;
using AwesomeRequestTrackerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeRequestTrackerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Employee>>> Get()
    {
        try
        {
            var employees = await _employeeService.GetEmployees();
            return Ok(employees.ToList());
        }
        catch (NoEmployeeFoundException nefe)
        {
            return NotFound(nefe.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Employee>> Post([FromBody]Employee employee)
    {
        try
        {
            var employees = await _employeeService.GetEmployees();
            return Ok(employees.First());
        }
        catch (NoEmployeeFoundException nefe)
        {
            return NotFound(nefe.Message);
        }
    }

    [Route("GetEmployeeByPhone")]
    [HttpPost]
    public async Task<ActionResult<Employee>> Get([FromBody] string phone)

    {
        try

        {
            var employee = await _employeeService.GetEmployeeByPhone(phone);

            return Ok(employee);
        }

        catch (NoSuchEmployeeException nefe)

        {
            return NotFound(nefe.Message);
        }
    }
}