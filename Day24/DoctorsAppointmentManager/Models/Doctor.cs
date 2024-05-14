namespace DoctorsAppointmentManager.Models;

public class Doctor: Person
{

    public int Experience { get; set; }
    public ICollection<Qualification> Qualification { get; set; }
    public ICollection<Speciality> Specialities { get; set; }
    
}