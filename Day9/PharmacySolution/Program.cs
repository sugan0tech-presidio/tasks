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
        private DrugService drugService;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Seed();
            program.RunMainMenu();
        }

        Program()
        {
            staffService = new StaffService(new StaffRepo());
            drugService = new DrugService(new DrugRepo());
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
            staffService.Add(staff1);
            staffService.Add(staff2);

            // "Clopidogrel+PPIs" => "Clopidogrel" and "PPIs"
            var drug1 = new Drug(1, "Clopidogrel", "Provider", DateTime.Now.AddDays(30), 10.99, true, "Antiplatelet Agent");
            drug1.QuantitiesWithDates.Add(DateTime.Now.AddDays(45), 100);
            drug1.Count = 100;
            var drug2 = new Drug(2, "PPIs", "Provider", DateTime.Now.AddDays(30), 10.99, true,
                "Gastric Acid Suppressant");
            drug2.QuantitiesWithDates.Add(DateTime.Now.AddDays(45), 100);
            drug2.Count = 100;
                
            // "Ramipril+Spironolactone" => "Ramipril" and "Spironolactone"
            var drug3 = new Drug(3, "Ramipril", "Provider", DateTime.Now.AddDays(60), 15.99, false, "ACE Inhibitor");
            drug3.QuantitiesWithDates.Add(DateTime.Now.AddDays(45), 100);
            drug3.Count = 100;
            var drug4 = new Drug(4, "Spironolactone", "Provider", DateTime.Now.AddDays(60), 15.99, false,
                    "Potasssium-Sparing Diuretic");
            drug4.QuantitiesWithDates.Add(DateTime.Now.AddDays(45), 100);
            drug4.Count = 100;

            drugService.Add(drug1);
            drugService.Add(drug2);
            drugService.Add(drug3);
            drugService.Add(drug4);
            
            Console.WriteLine("Seeds completed");
        }
    }
}