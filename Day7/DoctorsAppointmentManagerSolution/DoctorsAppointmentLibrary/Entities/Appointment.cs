namespace DoctorsAppointmentLibrary;

public class Appointment
{
    public int Id { get; set; }
    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
    public DateTime AppointmentDateTime { get; set; }
    public string Purpose { get; set; }

    public override string ToString()
    {
        return $"\tAppointment Id\t:\t{Id}\n" +
               $"\nPatient\t:\t{Patient.Name}" +
               $"\nDoctor\t:\t{Doctor.Name}" +
               $"\nTime\t:\t{AppointmentDateTime}" +
               $"\nPurpose\t:\t{Purpose}";
    }
}