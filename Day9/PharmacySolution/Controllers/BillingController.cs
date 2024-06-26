﻿using PharmacyManagement.Exceptions;
using PharmacyManagement.Services;
using PharmacyModels;

namespace PharmacyManagement.Controllers;

public class BillingController
{
    private readonly BillService _billService;
    private readonly PrescriptionController _prescriptionController;
    private readonly PatientService _patientService;
    private readonly AuthController _authController = new();

    public BillingController(BillService billService, PrescriptionController prescriptionController,
        PatientService patientService)
    {
        _patientService = patientService;
        _billService = billService;
        _prescriptionController = prescriptionController;
    }

    public void Run()
    {
        Console.WriteLine("Welcome to Billing!!!");
        if (_authController.Auth(Roles.Cashier))
            ShowMainMenu();
    }

    private void ShowMainMenu()
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

            try
            {
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
            catch (InvalidIdFormatException e)
            {
                Console.WriteLine(e);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e);
            }
        }
    }

    private void CreateBillFromConsole()
    {
        var bill = new Bill();
        Console.WriteLine("\n\t\t\tCreating Bill from Console...");
        // Here you can implement the logic to create a bill from user input
        // For example, you can ask for prescription details and generate the bill accordingly
        Console.Write("\nEnter the Patient/User Id:");
        int userId = int.Parse(Console.ReadLine() ?? throw new InvalidIdFormatException());

        var patient = _patientService.GetById(userId);
        bill.user = patient;
        bill.time = DateTime.Now;

        AddPrescription(bill);

        Console.WriteLine("\n\t\t\tCreated Bill");
        Console.WriteLine(bill);
        patient.LoyaltyScore = bill.Total / 100;
        _patientService.Update(patient);
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
        var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        _billService.Delete(id);
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
        double total = 0;
        double todaysTotal = 0;
        foreach (var bill in _billService.GetAll())
        {
            Console.WriteLine(bill);
            total += bill.Total;
            if (bill.time.Date.Equals(DateTime.Today))
            {
                todaysTotal += bill.Total;
            }
        }

        Console.WriteLine($"Total transaction occured\t: {total:F2}");
        Console.WriteLine($"Today's Total transaction occured: {total:F2}");
    }
}