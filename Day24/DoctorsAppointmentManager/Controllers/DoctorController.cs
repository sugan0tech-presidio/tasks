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
    [Route("UpdateExperience")]
    public async Task<ActionResult<Doctor>> UpdateExperience(int id, int experience)
    {
        var doctor = DoctorService.GetById(id).Result;
        doctor.Experience = experience;
        await DoctorService.Update(doctor);
        return Ok(doctor);
    }

    [HttpPost]
    public async Task<ActionResult<List<Doctor>>> GetAllDoctors([FromBody] string speciality)
    {
        return Ok(DoctorService.GetAll().Result
            .ToList().FindAll(doc => doc.Specialities.ToList().FindAll(spl => spl.Name.Equals(speciality)).Count > 0));
    }

    [HttpPut]
    [Route("Speciality")]
    public async Task<ActionResult<Doctor>> UpdateSpeciality(int id)
    {
        var doctor = DoctorService.GetById(id).Result;
        doctor.Specialities.Add(new Speciality{Id = 1, Name = "MBBS"});
        await DoctorService.Update(doctor);
        return Ok(doctor);
    }
}