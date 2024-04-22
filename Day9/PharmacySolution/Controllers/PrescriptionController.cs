using PharmacyManagement.Exceptions;
using PharmacyManagement.Repositories;
using PharmacyManagement.Services;
using PharmacyModels;

namespace PharmacyManagement.Controllers;

using System;

public class PrescriptionController
{
    private readonly PrescriptionService _prescriptionService;
    private readonly AuthController _authController = new();
    private readonly DrugService _drugService;

    public PrescriptionController(PrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService ??
                               throw new ArgumentNullException(nameof(prescriptionService),
                                   "Prescription service cannot be null.");
        _drugService = new DrugService(new DrugRepo());
    }

    /// <summary>
    ///  Runner for Prescription controllers
    /// </summary>
    public void Run()
    {
        Console.WriteLine("Welcome to Prescription Management System!");

        if (_authController.Auth())
        {
            ShowMainMenu();
        }
    }

    /// <summary>
    /// Prescriptions Main Menu
    /// </summary>
    private void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. List Prescriptions");
            Console.WriteLine("2. Add Prescription");
            Console.WriteLine("3. Update Prescription");
            Console.WriteLine("4. Delete Prescription");
            Console.WriteLine("5. Clear Console");
            Console.WriteLine("6. Logout");

            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        ListPrescriptions();
                        break;
                    case "2":
                        AddPrescription();
                        break;
                    case "3":
                        UpdatePrescription();
                        break;
                    case "4":
                        DeletePrescription();
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
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
            catch (DangerousDrugCombinationException e)
            {
                Console.WriteLine(e);
            }
            catch (ExpiredDrugException e)
            {
                Console.WriteLine(e);
            }
            catch (InvalidIdFormatException e)
            {
                Console.WriteLine(e);
            }
            catch (OutOfStockException e)
            {
                Console.WriteLine(e);
            }
            catch (NotEnoughDrugException e)
            {
                Console.WriteLine(e);
            }
        }
    }

    /// <summary>
    /// List all Prescriptions
    /// </summary>
    private void ListPrescriptions()
    {
        var prescriptions = _prescriptionService.GetAll();
        if (prescriptions.Count == 0)
        {
            Console.WriteLine("\t\t\tNo prescriptions found!!!");
            return;
        }

        Console.WriteLine("\nList of Prescriptions:");
        foreach (var prescription in prescriptions)
        {
            Console.WriteLine(prescription);
        }
    }

    /// <summary>
    /// Gets prescriptions info from console and adds it.
    /// </summary>
    private void AddPrescription()
    {
        var prescription = new Prescription();
        Console.WriteLine("\nEnter Prescription Details:");
        Console.Write("\nEnter Doctor name:");
        prescription.PrescribingDoctor = Console.ReadLine() ?? "";

        Console.Write("\nEnter the Drug Id:");
        var drugId =
            int.Parse(Console.ReadLine() ?? throw new InvalidIdFormatException("Not a proper Id format for Int"));

        var drug = _drugService.GetById(drugId);
        _drugService.ValidateDrug(drug);

        Console.Write("\nEnter the Drug Quantity:");
        var quantity = int.Parse(Console.ReadLine() ?? "0");

        _drugService.IsDrugAvailable(drug, quantity);


        prescription.Drug = _drugService.GetById(drugId);
        prescription.Quantity = quantity;

        Console.Write("\nAny Notes on Drug: ");
        prescription.Notes = Console.ReadLine() ?? "";

        _prescriptionService.Add(prescription);

        Console.WriteLine("Prescription added successfully.");
    }

    /// <summary>
    /// Builds and returns a saved Prescription
    /// </summary>
    /// <returns>Created Prescription object</returns>
    public Prescription GetPrescription()
    {
        var prescription = new Prescription();
        Console.WriteLine("\nEnter Prescription Details:");
        Console.Write("\nEnter Doctor name:");
        prescription.PrescribingDoctor = Console.ReadLine() ?? "";

        Console.Write("\nEnter the Drug Id:");
        var drugId =
            int.Parse(Console.ReadLine() ?? throw new InvalidIdFormatException("Please enter a valid Id format"));

        var drug = _drugService.GetById(drugId);
        _drugService.ValidateDrug(drug);

        Console.Write("\nEnter the Drug Quantity:");
        var quantity = int.Parse(Console.ReadLine() ?? "0");

        _drugService.IsDrugAvailable(drug, quantity);

        prescription.Drug = _drugService.GetById(drugId);
        prescription.Quantity = quantity;

        Console.Write("\nAny Notes on Drug: ");
        prescription.Notes = Console.ReadLine() ?? "";

        // Get patient, doctor, and medications details from user input

        // Call prescription service to add prescription
        // _prescriptionService.Add(new Prescription(...));
        _prescriptionService.Add(prescription);

        Console.WriteLine("Prescription added successfully.");
        return prescription;
    }

    private void UpdatePrescription()
    {
        Console.Write("\nEnter Prescription ID to update: ");
        var id = Convert.ToInt32(Console.ReadLine());

        // Check if the prescription exists and user has permission to update it
        // var prescription = _prescriptionService.GetById(id);
        // if (prescription == null)
        // {
        //     Console.WriteLine("Prescription not found.");
        //     return;
        // }
        // Add permission check here

        Console.WriteLine("\nEnter Updated Prescription Details:");
        // Get updated details from user input
        // Update prescription properties
        // Call prescription service to update prescription

        Console.WriteLine("Prescription updated successfully.");
    }

    private void DeletePrescription()
    {
        Console.Write("\nEnter Prescription ID to delete: ");
        var id = Convert.ToInt32(Console.ReadLine());

        _prescriptionService.Delete(id);

        // Check if the prescription exists and user has permission to delete it
        // var prescription = _prescriptionService.GetById(id);
        // if (prescription == null)
        // {
        //     Console.WriteLine("Prescription not found.");
        //     return;
        // }
        // Add permission check here

        // Call prescription service to delete prescription

        Console.WriteLine("Prescription deleted successfully.");
    }
}