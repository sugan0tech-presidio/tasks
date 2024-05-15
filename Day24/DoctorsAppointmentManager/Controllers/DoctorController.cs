using DoctorsAppointmentManager.Models;
using DoctorsAppointmentManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAppointmentManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController: ControllerBase
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
    
}