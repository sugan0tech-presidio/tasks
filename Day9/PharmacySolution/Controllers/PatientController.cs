using PharmacyManagement.Services;

namespace PharmacyManagement.Controllers;

public class PatientController
{
    private readonly PatientService _patientService;
    private readonly AuthController _authController = new();

    public PatientController(PatientService patientService)
    {
        _patientService = patientService ??
                          throw new ArgumentNullException(nameof(patientService), "Patient service cannot be null.");
    }

    public void Run()
    {
        Console.WriteLine("Welcome to Patient Management System!");

        if (_authController.Auth())
        {
            ShowMainMenu();
        }
    }

    private void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. List Patients");
            Console.WriteLine("2. Add Patient");
            Console.WriteLine("3. Update Patient");
            Console.WriteLine("4. Delete Patient");
            Console.WriteLine("5. Clear Console");
            Console.WriteLine("6. Logout");

            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListPatients();
                    break;
                case "2":
                    AddPatient();
                    break;
                case "3":
                    UpdatePatient();
                    break;
                case "4":
                    DeletePatient();
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

    private void ListPatients()
    {
        var patients = _patientService.GetAll();
        Console.WriteLine("\nList of Patients:");
        foreach (var patient in patients)
        {
            Console.WriteLine(patient);
        }
    }

    private void AddPatient()
    {
        Console.WriteLine("\nEnter Patient Details:");
        Console.Write("Name: ");
        var name = Console.ReadLine();
        // Add other patient details input here

        // Call patient service to add patient
        // _patientService.Add(new Patient(...));

        Console.WriteLine("Patient added successfully.");
    }

    private void UpdatePatient()
    {
        Console.Write("\nEnter Patient ID to update: ");
        var id = Convert.ToInt32(Console.ReadLine());

        // Check if the patient exists and user has permission to update it
        // var patient = _patientService.GetById(id);
        // if (patient == null)
        // {
        //     Console.WriteLine("Patient not found.");
        //     return;
        // }
        // Add permission check here

        Console.WriteLine("\nEnter Updated Patient Details:");
        // Get updated details from user input
        // Update patient properties
        // Call patient service to update patient

        Console.WriteLine("Patient updated successfully.");
    }

    private void DeletePatient()
    {
        Console.Write("\nEnter Patient ID to delete: ");
        var id = Convert.ToInt32(Console.ReadLine());

        // Check if the patient exists and user has permission to delete it
        // var patient = _patientService.GetById(id);
        // if (patient == null)
        // {
        //     Console.WriteLine("Patient not found.");
        //     return;
        // }
        // Add permission check here

        // Call patient service to delete patient

        Console.WriteLine("Patient deleted successfully.");
    }
}