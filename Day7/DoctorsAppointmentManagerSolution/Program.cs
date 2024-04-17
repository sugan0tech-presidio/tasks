using DoctorsAppointmentManager.Repository;

namespace DoctorsAppointmentManager;

internal class Program
{
    private static void Main(string[] args)
    {
        var doctorRepository = new DoctorRepository();
        var patientRepository = new PatientRepository();
        var appointmentRepository = new AppointmentRepository();
    }
}