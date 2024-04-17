using DoctorsAppointmentManager.Repository;

namespace DoctorsAppointmentManager;

internal class Program
{
    private static void Main(string[] args)
    {
        DoctorRepository doctorRepository = new DoctorRepository();
        PatientRepository patientRepository = new PatientRepository();
        AppointmentRepository appointmentRepository = new AppointmentRepository();
    }
}