namespace DoctorsAppointmentManager.Models;

public class Speciality: BaseEntity
{
    public string Name { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
}