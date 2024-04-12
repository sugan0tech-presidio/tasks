using DoctorManager.Helper;

namespace DoctorManager;

class Program
{
    static void Main(string[] args)
    {
        var size = DoctorHelper.GetNum("Total Doctors");
        var doctors = new Doctor[size];
        for (var i = 0; i < size; i++)
            doctors[i] = DoctorHelper.GetDoctor(i + 1);

        foreach (var doctor in doctors)
            doctor.Display();
        
        DoctorHelper.FilterBySpeciality(doctors);
    }
    
}