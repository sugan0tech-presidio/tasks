using PharmacyManagement.Repositories;
using PharmacyManagement.Services;

namespace PharmacyManagement.Controllers;

public class BillingController
{
        private readonly BillService _billService;

        public BillController(BillService billService)
        {
            _billService = new BillService(new BillRepo());
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Bill Management!");
            while (true)
            {
                Console.WriteLine("\n1. Create Bill");
                Console.WriteLine("2. Discard Bill");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateBillFromConsole();
                        break;
                    case "2":
                        DiscardBill();
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void CreateBillFromConsole()
        {
            Console.WriteLine("\nCreating Bill from Console...");
            // Here you can implement the logic to create a bill from user input
            // For example, you can ask for prescription details and generate the bill accordingly
        }

        private void DiscardBill()
        {
            Console.WriteLine("\nDiscarding Bill...");
            // Here you can implement the logic to discard the current bill
        }
}