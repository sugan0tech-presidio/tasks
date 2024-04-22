using PharmacyManagement.Controllers;
using PharmacyManagement.Repositories;
using PharmacyManagement.Services;
using PharmacyModels;

namespace PharmacyManagement
{
    class Program
    {
        private StaffController staffController;
        private DrugController drugController;
        private PatientController patientController;
        private PrescriptionController prescriptionController;
        private AuthController authController;
        private BillingController billingController;
        private StaffService staffService;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.SeedStaff();
            program.RunMainMenu();
        }

        Program()
        {
            staffService = new StaffService(new StaffRepo());
            var drugService = new DrugService(new DrugRepo());
            var patientService = new PatientService(new PatientRepo());
            var prescriptionService = new PrescriptionService(new PrescriptionRepo());
            var billService = new BillService(new BillRepo());

            staffController = new StaffController(staffService);
            drugController = new DrugController(drugService, staffService);
            patientController = new PatientController(patientService, staffService);
            prescriptionController = new PrescriptionController(prescriptionService, staffService);
            billingController = new BillingController(billService, prescriptionController);
        }

        private void RunMainMenu()
        {
            Console.WriteLine("Welcome to Pharmacy Management System!");

            while (true)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Staff Management");
                Console.WriteLine("2. Drug Management");
                Console.WriteLine("3. Patient Management");
                Console.WriteLine("4. Prescription Management");
                Console.WriteLine("5. Billing Management");
                Console.WriteLine("6. Exit");

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
                        billingController.Run();
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void SeedStaff()
        {

            // Seed staff data
            var staff1 = new Staff(
                new DateTime(1980, 1, 1),
                "John Doe",
                "1234567890",
                "1",
                30,
                "123 Main St"
            );
            staff1.Role = "Administrator"; // Assigning role
            staff1.Password = "1"; // Assigning password

            var staff2 = new Staff(
                new DateTime(1985, 2, 15),
                "Jane Smith",
                "0987654321",
                "jane@example.com",
                35,
                "456 Oak St"
            );
            staff2.Role = "Pharmacist"; // Assigning role
            staff2.Password = "pharma@123"; // Assigning password

            // Add staff to the repository
            staffService.Add(staff1);
            staffService.Add(staff2);

            Console.WriteLine("Staff data seeded successfully.");
        }
    }
}