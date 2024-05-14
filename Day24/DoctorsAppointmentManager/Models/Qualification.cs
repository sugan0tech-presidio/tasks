namespace DoctorsAppointmentManager.Models;

public class Qualification: BaseEntity
{
    public string Name { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
}