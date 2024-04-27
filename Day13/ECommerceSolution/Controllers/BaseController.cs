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
                        ListEntityMembers();
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

    private void ListEntityMembers()
    {
        var members = _entityService.GetAll();
        Console.WriteLine($"\nList of {_entityName}'s:");
        foreach (var entity in members)
        {
            Console.WriteLine(entity);
        }
    }

    // todo
    private void AddEntityMember()
    {
        Console.WriteLine($"\nEnter {_entityName} Details:");
        
        Console.WriteLine("Staff member added successfully.");
    }

    private void UpdateEntityMember()
    {
        Console.Write($"\nEnter {_entityName} ID to update: ");
        var id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Staff member updated successfully.");
    }

    private void DeleteEntityMember()
    {
        Console.Write($"\nEnter {_entityName} ID to delete: ");
        var id = Convert.ToInt32(Console.ReadLine());
        try
        {
            _entityService.Delete(id);
            Console.WriteLine($"{_entityName} deleted successfully.");
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
        }
    }
}