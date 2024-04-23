using DoctorsAppointmentManager.Repository;

namespace DoctorsAppointmentManager.controllers;

public class DoctorController : IBaseController
{
    private readonly DoctorRepository _doctorRepository;

    public DoctorController(DoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public void GetFromConsole()
    {
        // todo to be implemented late as of now it's no in the requirement
    }

    public void ListAll()
    {
        var res = _doctorRepository.GetAll();
        if (res.Count == 0)
        {
            Console.WriteLine("\nNo Doctors available!!!");
            return;
        }

        foreach (var doctor in res)
            Console.WriteLine(doctor.ToString());
    }

    public void Get(int id)
    {
        var doctor = _doctorRepository.Get(id);
        if (doctor != null)
            Console.WriteLine(doctor.ToString());
        else
            Console.WriteLine($"\nDoctor not presetn for the id\t:\t{id}");
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void FindBySpeciality()
    {
        Console.WriteLine("\n\nSelect the Specializations");
        var specializations = DoctorRepository.Specializations;
        for (var i = 0; i < specializations.Length; i++)
            Console.WriteLine($"{i + 1}. {specializations[i]}");

        var option = Console.ReadLine();
        if (!int.TryParse(option, out var optionPos) || optionPos > specializations.Length)
        {
            Console.WriteLine($"invalid entry {option}");
            return;
        }

        var speciality = specializations[optionPos - 1];
        var doctors = _doctorRepository.FilterBySpeciality(speciality);
        foreach (var doctor in doctors)
            Console.WriteLine(doctor.ToString());
        Console.WriteLine($"{doctors.Count} found!!!\n");
    }
}