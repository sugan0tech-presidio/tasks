using DoctorsAppointmentManager.Contexts;
using DoctorsAppointmentManager.Models;

namespace DoctorsAppointmentManager.Repos;

public class DoctorRepo: BaseRepo<Doctor>
{
    public DoctorRepo(DoctorAppointmentManagerContext context) : base(context)
    {
    }
}