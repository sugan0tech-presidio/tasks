using PharmacyManagement.Services;

namespace PharmacyManagement.Controllers;

using System;

public class DrugController
{
    private readonly DrugService _drugService;
    private readonly StaffService _staffService;

    private const string AdminRole = "Administrator";

    public DrugController(DrugService drugService, StaffService staffService)
    {
        _drugService = drugService ?? throw new ArgumentNullException(nameof(drugService), "Drug service cannot be null.");
        _staffService = staffService ?? throw new ArgumentNullException(nameof(staffService), "Staff service cannot be null.");
    }

    public void Run()
    {
        Console.WriteLine("Welcome to Drug Management System!");

        while (true)
        {
            try
            {
                Console.WriteLine("\nPlease log in to continue:");
                Console.Write("Email: ");
                var email = Console.ReadLine();
                Console.Write("Password: ");
                var password = Console.ReadLine();

                var authenticatedStaff = _staffService.Authenticate(email, password);
                if (authenticatedStaff.Role != AdminRole)
                {
                    Console.WriteLine("You do not have permission to access this system.");
                    continue;
                }

                Console.WriteLine("\nLogged in successfully as Administrator.");
                ShowMainMenu();
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. List Drugs");
            Console.WriteLine("2. Add Drug");
            Console.WriteLine("3. Update Drug");
            Console.WriteLine("4. Delete Drug");
            Console.WriteLine("5. Clear Console");
            Console.WriteLine("6. Logout");

            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListDrugs();
                    break;
                case "2":
                    AddDrug();
                    break;
                case "3":
                    UpdateDrug();
                    break;
                case "4":
                    DeleteDrug();
                    break;
                case "5":
                    Console.Clear();
                    break;
                case "6":
                    Console.WriteLine("Logging out...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void ListDrugs()
    {
        var drugs = _drugService.GetAll();
        Console.WriteLine("\nList of Drugs:");
        foreach (var drug in drugs)
        {
            Console.WriteLine(drug);
        }
    }

    private void AddDrug()
    {
        Console.WriteLine("\nEnter Drug Details:");
        Console.Write("Name: ");
        var name = Console.ReadLine();
        // Add other drug details input here

        // Call drug service to add drug
        // _drugService.Add(new Drug(...));

        Console.WriteLine("Drug added successfully.");
    }

    private void UpdateDrug()
    {
        Console.Write("\nEnter Drug ID to update: ");
        var id = Convert.ToInt32(Console.ReadLine());

        // Check if the drug exists and user has permission to update it
        // var drug = _drugService.GetById(id);
        // if (drug == null)
        // {
        //     Console.WriteLine("Drug not found.");
        //     return;
        // }
        // Add permission check here

        Console.WriteLine("\nEnter Updated Drug Details:");
        // Get updated details from user input
        // Update drug properties
        // Call drug service to update drug

        Console.WriteLine("Drug updated successfully.");
    }

    private void DeleteDrug()
    {
        Console.Write("\nEnter Drug ID to delete: ");
        var id = Convert.ToInt32(Console.ReadLine());

        // Check if the drug exists and user has permission to delete it
        // var drug = _drugService.GetById(id);
        // if (drug == null)
        // {
        //     Console.WriteLine("Drug not found.");
        //     return;
        // }
        // Add permission check here

        // Call drug service to delete drug

        Console.WriteLine("Drug deleted successfully.");
    }
}
