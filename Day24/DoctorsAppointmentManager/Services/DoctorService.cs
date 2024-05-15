using DoctorsAppointmentManager.Models;
using DoctorsAppointmentManager.Repos;

namespace DoctorsAppointmentManager.Services;

public class DoctorService : BaseService<Doctor>
{
    public DoctorService(IBaseRepo<Doctor> repository) : base(repository)
    {
    }
}