namespace DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

public class Appointment
{
    public Appointment(Doctor doctor, Patient patient, DateTime appointmentDateTime, string purpose)
    {
        Doctor = doctor;
        Patient = patient;
        AppointmentDateTime = appointmentDateTime;
        Purpose = purpose;
    }

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