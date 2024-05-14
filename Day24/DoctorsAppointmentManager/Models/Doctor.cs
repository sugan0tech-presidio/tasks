namespace DoctorsAppointmentManager.Models;

public class Doctor: Person
{

    public int Experience { get; set; }
    public List<Qualification> Qualification { get; set; }
    public List<Speciality> Specialities { get; set; }
    
}