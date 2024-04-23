using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;
using DoctorsAppointmentManager.Repository;

namespace DoctorsAppointmentManager;

internal class Program
{
    private DoctorRepository _doctorRepository;
    private PatientRepository _patientRepository;
    private AppointmentRepository _appointmentRepository;

    public Program(DoctorRepository doctorRepository, PatientRepository patientRepository, AppointmentRepository appointmentRepository)
    {
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
        _appointmentRepository = appointmentRepository;
    }

    
    private static void Main(string[] args)
    {
        // to be presistant throughout the program
        Program program = new Program(new DoctorRepository(), new PatientRepository(), new AppointmentRepository());
        var doc1 = new Doctor(new DateTime(2000, 12, 12), "james", "87723889988", "siid@gmail.com", 23,
            "lane1, chennai", 10);
        doc1.AddSpecialization(DoctorRepository.Specializations[0]);
        doc1.AddQualification(DoctorRepository.Qualifications[0]);
        doc1.AddQualification(DoctorRepository.Qualifications[2]);
        
        var doc2 = new Doctor(new DateTime(1990, 12, 12), "vames", "8383892833", "divid@gmail.com", 60,
            "lane1, banglore", 12);
        doc2.AddSpecialization(DoctorRepository.Specializations[2]);
        doc2.AddQualification(DoctorRepository.Qualifications[0]);
        doc2.AddQualification(DoctorRepository.Qualifications[1]);

        program._doctorRepository.Add(doc1);
        program._doctorRepository.Add(doc2);

        foreach (var doctor in program._doctorRepository.GetAll())
        {
            Console.WriteLine(doctor);
        }
    }
}