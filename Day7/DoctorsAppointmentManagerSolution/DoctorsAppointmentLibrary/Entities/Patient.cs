namespace DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

public class Patient : Person
{
    public string InsuranceProvider { get; set; }
    public string MedicalHistory { get; set; }

    public override string ToString()
    {
        // todo to move this to base.
        return base.ToString()
               + $"Patient {Id} Details:\n"
               + $"\tPatient Name\t:\t{Name}\n"
               + $"\tPatient DOB\t:\t{DateOfBirth}\n"
               + $"\tPatient Age\t:\t{Age}\n"
               + $"\tPatient InsuranceProvider\t:\t{InsuranceProvider}\n";
    }
}