using PharmacyManagement.Controllers;
using PharmacyManagement.Repositories;
using PharmacyManagement.Services;
using PharmacyModels;

namespace PharmacyManagement
{
    class Program
    {
        private readonly StaffController _staffController;
        private readonly DrugController _drugController;
        private readonly PatientController _patientController;
        private readonly PrescriptionController _prescriptionController;
        private readonly AuthController _authController;
        private readonly BillingController _billingController;
        private readonly StaffService _staffService;
        private readonly DrugService _drugService;
        private readonly PatientService _patientService;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Seed();
            program.RunMainMenu();
        }

        Program()
        {
            _authController = new AuthController();
            _staffService = new StaffService(new StaffRepo());
            _drugService = new DrugService(new DrugRepo());
            _patientService = new PatientService(new PatientRepo());
            var prescriptionService = new PrescriptionService(new PrescriptionRepo());
            var billService = new BillService(new BillRepo());

            _staffController = new StaffController(_staffService);
            _drugController = new DrugController(_drugService);
            _patientController = new PatientController(_patientService);
            _prescriptionController = new PrescriptionController(prescriptionService);
            _billingController = new BillingController(billService, _prescriptionController);
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
                        _staffController.Run();
                        break;
                    case "2":
                        _drugController.Run();
                        break;
                    case "3":
                        _patientController.Run();
                        break;
                    case "4":
                        _prescriptionController.Run();
                        break;
                    case "5":
                        _billingController.Run();
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

        public void Seed()
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
            _staffService.Add(staff1);
            _staffService.Add(staff2);

            // "Clopidogrel+PPIs" => "Clopidogrel" and "PPIs"
            var drug1 = new Drug(1, "Clopidogrel", "Provider", 10.99, true, "Antiplatelet Agent");
            drug1.QuantitiesWithDates.Add(DateTime.Now.AddDays(45), 100);
            drug1.Count = 100;
            var drug2 = new Drug(2, "PPIs", "Provider", 10.99, true,
                "Gastric Acid Suppressant");
            drug2.QuantitiesWithDates.Add(DateTime.Now.AddDays(45), 100);
            drug2.Count = 100;

            // "Ramipril+Spironolactone" => "Ramipril" and "Spironolactone"
            var drug3 = new Drug(3, "Ramipril", "Provider", 15.99, false, "ACE Inhibitor");
            drug3.QuantitiesWithDates.Add(DateTime.Now.AddDays(45), 100);
            drug3.Count = 100;
            var drug4 = new Drug(4, "Spironolactone", "Provider", 15.99, false,
                "Potasssium-Sparing Diuretic");
            drug4.QuantitiesWithDates.Add(DateTime.Now.AddDays(45), 100);
            drug4.Count = 100;

            _drugService.Add(drug1);
            _drugService.Add(drug2);
            _drugService.Add(drug3);
            _drugService.Add(drug4);

            // First Patient object assignment
            Patient patient1 = new Patient(
                new DateTime(1980, 5, 15), // Date of Birth
                1001, // ID
                "John Doe", // Name
                "1234567890", // Contact Number
                "john.doe@example.com", // Email
                42, // Age
                "123 Main St, Cityville", // Address
                "Health Insurance Inc.", // Insurance Provider
                "Hypertension, Diabetes" // Medical History
            );

// Second Patient object assignment
            Patient patient2 = new Patient(
                new DateTime(1975, 9, 20), // Date of Birth
                1002, // ID
                "Jane Smith", // Name
                "9876543210", // Contact Number
                "jane.smith@example.com", // Email
                47, // Age
                "456 Oak Ave, Townsville", // Address
                "Medicare", // Insurance Provider
                "Asthma, Allergies" // Medical History
            );

            patient2.LoyaltyScore = 10;

            _patientService.Add(patient1);
            _patientService.Add(patient2);

            Console.WriteLine("Seeds completed");
        }
    }
}