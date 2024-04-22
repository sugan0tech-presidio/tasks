using PharmacyManagement.Exceptions;
using PharmacyManagement.Services;
using PharmacyModels;

namespace PharmacyManagement.Controllers;

using System;

public class DrugController
{
    private readonly DrugService _drugService;
    private readonly AuthController _authController = new();

    public DrugController(DrugService drugService)
    {
        _drugService = drugService ??
                       throw new ArgumentNullException(nameof(drugService), "Drug service cannot be null.");
    }

    /// <summary>
    /// Runner for Drug controller
    /// </summary>
    public void Run()
    {
        Console.WriteLine("Welcome to Drug Management System!");

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
            Console.WriteLine("1. List Drugs");
            Console.WriteLine("2. Add Drug");
            Console.WriteLine("3. Update Drug");
            Console.WriteLine("4. Delete Drug");
            Console.WriteLine("5. Clear Console");
            Console.WriteLine("6. Logout");

            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        ListDrugs();
                        break;
                    case "2":
                        AddDrug();
                        break;
                    case "3":
                        UpdateStash();
                        break;
                    case "4":
                        DeleteDrug();
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
            catch (UserNotAuthorisedException e)
            {
                Console.WriteLine(e);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
        }
    }

    /// <summary>
    ///  Prints list of all drugs.
    /// </summary>
    private void ListDrugs()
    {
        var drugs = _drugService.GetAll();
        Console.WriteLine("\nList of Drugs:");
        foreach (var drug in drugs)
        {
            Console.WriteLine(drug);
        }
    }

    /// <summary>
    /// Adds drug from console
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    private void AddDrug()
    {
        var drug = new Drug();
        Console.WriteLine("\nEnter Drug Details:");
        Console.Write("\nName: ");
        drug.Name = Console.ReadLine() ?? throw new InvalidOperationException("Enter a valid string of Drug Name");

        Console.Write("\nProvider: ");
        drug.Provider = Console.ReadLine() ?? "";

        Console.Write("\nPrice: ");
        drug.price = double.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("\nClassification: ");
        drug.Classification = Console.ReadLine() ?? "";

        Console.WriteLine("\nIsPrescriptionNeeded: ");
        drug.PrescriptionNeeded = bool.Parse(Console.ReadLine() ?? "false");

        _drugService.Add(drug);
        Console.WriteLine("Drug added successfully.");
    }

    /// <summary>
    /// Updates drug's stash
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    private void UpdateStash()
    {
        Console.Write("\nEnter Drug ID to add More: ");
        var id = Convert.ToInt32(Console.ReadLine());

        var drug = _drugService.GetById(id);

        Console.WriteLine("\nEnter New Stash Expiry");
        var expiryDate = DateTime.Parse(Console.ReadLine() ??
                                        throw new InvalidOperationException("Enter a valid Expiry date format"));
        Console.WriteLine("\nEnter New Stash quantity");
        var quantity =
            int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Enter valid data for quantity"));

        drug.AddNewStash(expiryDate, quantity);

        Console.WriteLine("Drug added successfully.");
    }

    /// <summary>
    ///  Deletes a drug
    /// </summary>
    private void DeleteDrug()
    {
        Console.Write("\nEnter Drug ID to delete: ");
        var id = Convert.ToInt32(Console.ReadLine());
        if (!_authController.HasAuthority("Administrator"))
            throw new UserNotAuthorisedException("You don't have permission to delete Drug");

        try
        {
            _drugService.Delete(id);
            Console.WriteLine("Drug deleted successfully.");
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
        }
    }
}