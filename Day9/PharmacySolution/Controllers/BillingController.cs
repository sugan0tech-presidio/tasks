using PharmacyManagement.Services;
using PharmacyModels;

namespace PharmacyManagement.Controllers;

public class BillingController
{
    private readonly BillService _billService;
    private readonly PrescriptionController _prescriptionController;

    public BillingController(BillService billService, PrescriptionController prescriptionController)
    {
        _billService = billService;
        _prescriptionController = prescriptionController;
    }

    public void Run()
    {
        Console.WriteLine("Welcome to Bill Management!");
        while (true)
        {
            Console.WriteLine("\n1. Create Bill");
            Console.WriteLine("2. Discard Bill");
            Console.WriteLine("3. View Bill");
            Console.WriteLine("4. View All Bill");
            Console.WriteLine("5. Exit");
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
                    ViewById();
                    break;
                case "4":
                    ViewAll();
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

    private void CreateBillFromConsole()
    {
        var bill = new Bill();
        Console.WriteLine("\n\t\t\tCreating Bill from Console...");
        // Here you can implement the logic to create a bill from user input
        // For example, you can ask for prescription details and generate the bill accordingly
        Console.Write("\nEnter the user Name:");
        bill.user = Console.ReadLine() ?? "";

        AddPrescription(bill);

        Console.WriteLine("\n\t\t\tCreated Bill");
        Console.WriteLine(bill);
    }

    private void AddPrescription(Bill bill)
    {
        while (true)
        {
            Console.Write("\nAre you want to add prescription y/n:");
            var opt = Console.ReadLine() ?? "n";
            if (opt != "y")
            {
                return;
            }

            var prescription = _prescriptionController.GetPrescription();
            _billService.AddPrescription(bill, prescription);
        }
    }

    private void DiscardBill()
    {
        Console.WriteLine("\nDiscarding Bill...");
        // Here you can implement the logic to discard the current bill
    }

    private void ViewById()
    {
        Console.Write("\nEnter the Bill Id:");
        try
        {
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine(_billService.GetById(id));
        }
        catch (FormatException e)
        {
            Console.WriteLine(e);
        }
        catch (InvalidCastException e)
        {
            Console.WriteLine(e);
        }
    }

    private void ViewAll()
    {
        foreach (var bill in _billService.GetAll())
        {
            Console.WriteLine(bill);
        }
    }
}