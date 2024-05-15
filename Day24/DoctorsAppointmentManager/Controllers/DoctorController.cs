using DoctorsAppointmentManager.Models;
using DoctorsAppointmentManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAppointmentManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IService<Doctor> DoctorService;

    public DoctorController(IService<Doctor> doctorService)
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
        return Ok(DoctorService.GetAll().Result
            .ToList().FindAll(doc => doc.Speciality.Equals(speciality)));
    }
    
    [HttpGet("{id:int}")] // Same as with seperate route with that path
    public async Task<ActionResult<Doctor>> GetDoctorById(int id)
    {
        return Ok(DoctorService.GetById(id));
    }
    
    [HttpPost]
    public async Task<ActionResult<Doctor>> CreateDoctor([FromBody]Doctor doctor)
    {
        DoctorService.Add(doctor);
        return Ok(doctor);
    }

    [HttpPut]
    [Route("Experience")]
    public async Task<ActionResult<Doctor>> UpdateExperience(int id, int experience)
    {
        var doctor = DoctorService.GetById(id).Result;
        doctor.Experience = experience;
        await DoctorService.Update(doctor);
        return Ok(doctor);
    }

    [HttpPut]
    [Route("Speciality")]
    public async Task<ActionResult<Doctor>> UpdateSpeciality(int id, Speciality speciality)
    {
        var doctor = DoctorService.GetById(id).Result;
        doctor.Speciality = speciality;
        await DoctorService.Update(doctor);
        return Ok(doctor);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteById(int id)
    {
        var status  = DoctorService.Delete(id);
        return Ok(status);
    }
}