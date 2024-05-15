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
        return Ok(DoctorService.GetAllBySpeciality(speciality));
    }

    [HttpGet("{id:int}")] // Same as with seperate route with that path
    public async Task<ActionResult<Doctor>> GetDoctorById(int id)
    {
        return Ok(DoctorService.GetById(id));
    }

    [HttpPost]
    public async Task<ActionResult<Doctor>> CreateDoctor([FromBody] Doctor doctor)
    {
        DoctorService.Add(doctor);
        return Ok(doctor);
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
        var status = DoctorService.Delete(id);
        return Ok(status);
    }
}