using PharmacyManagement.Controllers;
using PharmacyManagement.Repositories;
using PharmacyManagement.Services;

namespace PharmacyManagement;

class Program
{
    static void Main(string[] args)
    {
        var staffService = new StaffService(new StaffRepo()); // Initialize StaffService
        var drugService = new DrugService(new DrugRepo()); // Initialize DrugService
        var patientService = new PatientService(new PatientRepo()); // Initialize PatientService
        var prescriptionService = new PrescriptionService(new PrescriptionRepo()); // Initialize PrescriptionService

        var staffController = new StaffController(staffService); // Initialize StaffConsoleController
        var drugController = new DrugController(drugService, staffService); // Initialize DrugConsoleController
        var patientController = new PatientController(patientService, staffService); // Initialize PatientConsoleController
        var prescriptionController = new PrescriptionController(prescriptionService, staffService); // Initialize PrescriptionConsoleController

        Console.WriteLine("Welcome to Pharmacy Management System!");

        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Staff Management");
            Console.WriteLine("2. Drug Management");
            Console.WriteLine("3. Patient Management");
            Console.WriteLine("4. Prescription Management");
            Console.WriteLine("5. Exit");

            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    staffController.Run();
                    break;
                case "2":
                    drugController.Run();
                    break;
                case "3":
                    patientController.Run();
                    break;
                case "4":
                    prescriptionController.Run();
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}