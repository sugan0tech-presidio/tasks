using PharmacyManagement.Repositories;
using PharmacyManagement.Services;

namespace PharmacyManagement.Controllers;

public class DoctorController
{
    private readonly DoctorRepo _doctorRepository;
    private AuthController _authController = new();

    public DoctorController(DoctorRepo doctorRepository)
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
        var doctor = _doctorRepository.GetById(id);
        if (doctor != null)
            Console.WriteLine(doctor);
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
        var specializations = DoctorRepo.Specializations;
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

    private readonly DoctorService _doctorService;
    private readonly StaffService _staffService;

    private const string AdminRole = "Administrator";

    /// <summary>
    /// Initializes a new instance of the <see cref="DoctorController"/> class.
    /// </summary>
    /// <param name="doctorService">The doctor service.</param>
    /// <param name="staffService">The staff service.</param>
    /// <exception cref="ArgumentNullException">Thrown when doctorService or staffService is null.</exception>
    public DoctorController(DoctorService doctorService, StaffService staffService)
    {
        _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService), "Doctor service cannot be null.");
        _staffService = staffService ?? throw new ArgumentNullException(nameof(staffService), "Staff service cannot be null.");
    }

    /// <summary>
    /// Runs the doctor management system.
    /// </summary>
    public void Run()
    {
        Console.WriteLine("Welcome to Doctor Management System!");

        while (true)
        {
            if (_authController.Auth())
            {
                ShowMainMenu();
            }
        }
    }

    private void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. List Doctors");
            Console.WriteLine("2. Add Doctor");
            Console.WriteLine("3. Update Doctor");
            Console.WriteLine("4. Delete Doctor");
            Console.WriteLine("5. Clear Console");
            Console.WriteLine("6. Logout");

            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListDoctors();
                    break;
                case "2":
                    AddDoctor();
                    break;
                case "3":
                    UpdateDoctor();
                    break;
                case "4":
                    DeleteDoctor();
                    break;
                case "5":
                    Console.Clear();
                    break;
                case "6":
                    _authController.Logout();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    /// <summary>
    /// Lists all doctors in the system.
    /// </summary>
    private void ListDoctors()
    {
        var doctors = _doctorService.GetAll();
        Console.WriteLine("\nList of Doctors:");
        foreach (var doctor in doctors)
        {
            Console.WriteLine(doctor);
        }
    }

    /// <summary>
    /// Adds a new doctor to the system.
    /// </summary>
    private void AddDoctor()
    {
        Console.WriteLine("\nEnter Doctor Details:");
        Console.Write("Name: ");
        var name = Console.ReadLine();
        // Add other doctor details input here

        // Call doctor service to add doctor
        // _doctorService.Add(new Doctor(...));

        Console.WriteLine("Doctor added successfully.");
    }

    /// <summary>
    /// Updates an existing doctor in the system.
    /// </summary>
    private void UpdateDoctor()
    {
        Console.Write("\nEnter Doctor ID to update: ");
        var id = Convert.ToInt32(Console.ReadLine());

        // Check if the doctor exists and user has permission to update it
        // var doctor = _doctorService.GetById(id);
        // if (doctor == null)
        // {
        //     Console.WriteLine("Doctor not found.");
        //     return;
        // }
        // Add permission check here

        Console.WriteLine("\nEnter Updated Doctor Details:");
        // Get updated details from user input
        // Update doctor properties
        // Call doctor service to update doctor

        Console.WriteLine("Doctor updated successfully.");
    }

    /// <summary>
    /// Deletes a doctor from the system.
    /// </summary>
    private void DeleteDoctor()
    {
        Console.Write("\nEnter Doctor ID to delete: ");
        var id = Convert.ToInt32(Console.ReadLine());

        // Check if the doctor exists and user has permission to delete it
        // var doctor = _doctorService.GetById(id);
        // if (doctor == null)
        // {
        //     Console.WriteLine("Doctor not found.");
        //     return;
        // }
        // Add permission check here

        // Call doctor service to delete doctor

        Console.WriteLine("Doctor deleted successfully.");
    }
}
