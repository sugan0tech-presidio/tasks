using PharmacyManagement.Services;

namespace PharmacyManagement.Controllers;

using System;

public class StaffConsoleController
{
    private readonly StaffService _staffService;

    private const string AdminRole = "Administrator";

    public StaffConsoleController(StaffService staffService)
    {
        _staffService = staffService ?? throw new ArgumentNullException(nameof(staffService), "Staff service cannot be null.");
    }

    public void Run()
    {
        Console.WriteLine("Welcome to Staff Management System!");

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
            Console.WriteLine("1. List Staff Members");
            Console.WriteLine("2. Add Staff Member");
            Console.WriteLine("3. Update Staff Member");
            Console.WriteLine("4. Delete Staff Member");
            Console.WriteLine("5. Clear Console");
            Console.WriteLine("6. Logout");

            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListStaffMembers();
                    break;
                case "2":
                    AddStaffMember();
                    break;
                case "3":
                    UpdateStaffMember();
                    break;
                case "4":
                    DeleteStaffMember();
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

    private void ListStaffMembers()
    {
        var staffMembers = _staffService.GetAll();
        Console.WriteLine("\nList of Staff Members:");
        foreach (var staffMember in staffMembers)
        {
            Console.WriteLine(staffMember);
        }
    }

    private void AddStaffMember()
    {
        Console.WriteLine("\nEnter Staff Member Details:");
        Console.Write("Name: ");
        var name = Console.ReadLine();
        // Add other staff member details input here

        // Call staff service to add staff member
        // _staffService.Add(new Staff(...));

        Console.WriteLine("Staff member added successfully.");
    }

    private void UpdateStaffMember()
    {
        Console.Write("\nEnter Staff Member ID to update: ");
        var id = Convert.ToInt32(Console.ReadLine());

        // Check if the staff member exists and user has permission to update it
        // var staffMember = _staffService.GetById(id);
        // if (staffMember == null)
        // {
        //     Console.WriteLine("Staff member not found.");
        //     return;
        // }
        // Add permission check here

        Console.WriteLine("\nEnter Updated Staff Member Details:");
        // Get updated details from user input
        // Update staff member properties
        // Call staff service to update staff member

        Console.WriteLine("Staff member updated successfully.");
    }

    private void DeleteStaffMember()
    {
        Console.Write("\nEnter Staff Member ID to delete: ");
        var id = Convert.ToInt32(Console.ReadLine());

        // Check if the staff member exists and user has permission to delete it
        // var staffMember = _staffService.GetById(id);
        // if (staffMember == null)
        // {
        //     Console.WriteLine("Staff member not found.");
        //     return;
        // }
        // Add permission check here

        // Call staff service to delete staff member

        Console.WriteLine("Staff member deleted successfully.");
    }
}
