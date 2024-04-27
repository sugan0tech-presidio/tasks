using ECommerceApp.Entities;
using ECommerceApp.Services;

namespace ECommerceApp.Controllers;

public class BaseController<TBaseEntity> where TBaseEntity: IEntity
{
    private readonly BaseService<TBaseEntity> _entityService;
    private readonly string _entityName = typeof(TBaseEntity).Name;

    public BaseController(BaseService<TBaseEntity> entityService)
    {
        _entityService = entityService ??
                        throw new ArgumentNullException(nameof(entityService), "Staff service cannot be null.");
        _entityService = entityService;
    }

    public void Run()
    {
        Console.WriteLine($"Welcome to {_entityName} Management System!");
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine($"\n{_entityName}'s Menu:");
            Console.WriteLine($"1. List {_entityName}'s ");
            Console.WriteLine($"2. Add {_entityName} ");
            Console.WriteLine($"3. Update {_entityName} ");
            Console.WriteLine($"4. Delete {_entityName} ");
            Console.WriteLine("5. Clear Console");
            Console.WriteLine("6. exit to Main Menu");

            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        ListEntiyMembers();
                        break;
                    case "2":
                        AddEntityMember();
                        break;
                    case "3":
                        UpdateEntityMember();
                        break;
                    case "4":
                        DeleteEntityMember();
                        break;
                    case "5":
                        Console.Clear();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e);
            }
        }
    }

    private void ListEntiyMembers()
    {
        var members = _entityService.GetAll();
        Console.WriteLine("\nList of Staff Members:");
        foreach (var entity in members)
        {
            Console.WriteLine(entity);
        }
    }

    // todo
    private void AddEntityMember()
    {
        Console.WriteLine("\nEnter Staff Member Details:");
        Console.Write("Name: ");
        var name = Console.ReadLine();
        // Add other staff member details input here

        // Call staff service to add staff member
        // _staffService.Add(new Staff(...));

        Console.WriteLine("Staff member added successfully.");
    }

    private void UpdateEntityMember()
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

    private void DeleteEntityMember()
    {
        Console.Write("\nEnter Staff Member ID to delete: ");
        var id = Convert.ToInt32(Console.ReadLine());
        try
        {
            _entityService.Delete(id);
            Console.WriteLine("Staff member deleted successfully.");
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
        }
    }
}