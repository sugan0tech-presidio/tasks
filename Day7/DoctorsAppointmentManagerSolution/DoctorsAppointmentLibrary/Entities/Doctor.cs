namespace DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

public class Doctor : Person
{
    public string Specialization { get; set; }
    public string Qualification { get; set; }
    public override string ToString()
    {
        // todo to move this to base.
        return base.ToString()
               +$"Doctor {Id} Details:\n"
               +$"\tDoctor Name\t:\t{Name}\n"
               +$"\tDoctor DOB\t:\t{DateOfBirth}\n"
               +$"\tDoctor Age\t:\t{Age}\n"
               +$"\tDoctor Specialization\t:\t{Specialization}\n"
               + $"\tDoctor Qualification\t:\t{Qualification}\n";
    }
}