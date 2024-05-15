using DoctorsAppointmentManager.Models;
using DoctorsAppointmentManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAppointmentManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService DoctorService;

    public DoctorController(IDoctorService doctorService)
    {
        DoctorService = doctorService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Doctor>>> GetAllDoctors()
    {
        return Ok(DoctorService.GetAll());
    }

    [HttpGet]
    [Route("Speciality")]
    public async Task<ActionResult<List<Doctor>>> GetAllDoctors(Speciality speciality)
    {
        try
        {
            return Ok(DoctorService.GetAllBySpeciality(speciality));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("{id:int}")] // Same as with seperate route with that path
    public async Task<ActionResult<Doctor>> GetDoctorById(int id)
    {
        try
        {
            return Ok(DoctorService.GetById(id));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Doctor>> CreateDoctor([FromBody] Doctor doctor)
    {
        try
        {
            DoctorService.Add(doctor);
            return Ok(doctor);
        }
        catch (Exception e)
        {
            return UnprocessableEntity(e.Message);
        }
    }

    [HttpPut]
    [Route("Experience")]
    public async Task<ActionResult<Doctor>> UpdateExperience(int id, int experience)
    {
        return Ok(DoctorService.UpdateExperience(id, experience));
    }

    [HttpPut]
    [Route("Speciality")]
    public async Task<ActionResult<Doctor>> UpdateSpeciality(int id, Speciality speciality)
    {
        return Ok(DoctorService.UpdateSpeciality(id, speciality));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteById(int id)
    {
        try
        {
            var status = DoctorService.Delete(id);
            return Ok(status);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}