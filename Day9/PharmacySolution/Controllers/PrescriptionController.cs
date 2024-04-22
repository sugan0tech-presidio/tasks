using PharmacyManagement.Repositories;
using PharmacyManagement.Services;
using PharmacyModels;

namespace PharmacyManagement.Controllers;

using System;

public class PrescriptionController
{
    private readonly PrescriptionService _prescriptionService;
    private readonly StaffService _staffService;
    private AuthController _authController = new();
    private readonly DrugService _drugService;

    public PrescriptionController(PrescriptionService prescriptionService, StaffService staffService)
    {
        _prescriptionService = prescriptionService ?? throw new ArgumentNullException(nameof(prescriptionService), "Prescription service cannot be null.");
        _staffService = staffService ?? throw new ArgumentNullException(nameof(staffService), "Staff service cannot be null.");
        _drugService = new DrugService(new DrugRepo());
    }

    public void Run()
    {
        Console.WriteLine("Welcome to Prescription Management System!");

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
            Console.WriteLine("1. List Prescriptions");
            Console.WriteLine("2. Add Prescription");
            Console.WriteLine("3. Update Prescription");
            Console.WriteLine("4. Delete Prescription");
            Console.WriteLine("5. Clear Console");
            Console.WriteLine("6. Logout");

            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

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
    }

    private void ListPrescriptions()
    {
        var prescriptions = _prescriptionService.GetAll();
        Console.WriteLine("\nList of Prescriptions:");
        foreach (var prescription in prescriptions)
        {
            Console.WriteLine(prescription);
        }
    }

    private void AddPrescription()
    {
        var prescription = new Prescription();
        Console.WriteLine("\nEnter Prescription Details:");
        Console.Write("\nEnter Doctor name:");
        prescription.PrescribingDoctor = Console.ReadLine()??"";
        
        Console.Write("\nEnter the Drug Id:");
        var drugId = int.Parse(Console.ReadLine());
        
        var drug = _drugService.GetById(drugId);
        if (!validateDrug(drug))
            return;
        
        Console.Write("\nEnter the Drug Quantity:");
        var quantity = int.Parse(Console.ReadLine());
        
        if (!isDrugAvailable(drug, quantity))
            return;


        prescription.Drug = _drugService.GetById(drugId);
        prescription.Quantity = quantity;

        Console.Write("\nAny Notes on Drug: ");
        prescription.Notes = Console.ReadLine()??"";
        
        // Get patient, doctor, and medications details from user input

        // Call prescription service to add prescription
        // _prescriptionService.Add(new Prescription(...));
        _prescriptionService.Add(prescription);

        Console.WriteLine("Prescription added successfully.");
    }
    
    public Prescription GetPrescription()
    {
        var prescription = new Prescription();
        Console.WriteLine("\nEnter Prescription Details:");
        Console.Write("\nEnter Doctor name:");
        prescription.PrescribingDoctor = Console.ReadLine()??"";
        
        Console.Write("\nEnter the Drug Id:");
        var drugId = int.Parse(Console.ReadLine());
        
        var drug = _drugService.GetById(drugId);
        if (!validateDrug(drug))
            return null;
        
        Console.Write("\nEnter the Drug Quantity:");
        var quantity = int.Parse(Console.ReadLine());
        
        if (!isDrugAvailable(drug, quantity))
            return null;
        
        
        prescription.Drug = _drugService.GetById(drugId);
        prescription.Quantity = quantity;


        Console.Write("\nAny Notes on Drug: ");
        prescription.Notes = Console.ReadLine()??"";
        
        // Get patient, doctor, and medications details from user input

        // Call prescription service to add prescription
        // _prescriptionService.Add(new Prescription(...));
        _prescriptionService.Add(prescription);

        Console.WriteLine("Prescription added successfully.");
        return prescription;
    }

    private bool isDrugAvailable(Drug drug, int quantity)
    {
        if (drug.Count > 0)
        {
            Console.WriteLine("\nDrug is out of stock!!!");
            return false;
        }
        if (drug.Count < quantity)
        {
            Console.WriteLine("\nDrug is not enough!!!");
        }
        return true;
    }

    private bool validateDrug(Drug drug)
    {
        var minExpiryDate = drug.QuantitiesWithDates.Keys.Min();
        var currentDate = DateTime.Today;
        if (drug.PrescriptionNeeded)
        {
            Console.WriteLine("Note this drugs needs doctors approval!!!");
        }

        if (currentDate >= minExpiryDate)
        {
            Console.WriteLine("Few drug are expired!! Update in Store!!");
            return false;
        }
        
        if (minExpiryDate < currentDate.AddDays(30))
        {
            Console.WriteLine("Drug gonna Expire soon!!!");
        }

        return true;
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
