using AwesomeRequestTracker.Exceptions;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Serivces;

namespace AwesomeRequestTracker.Controllers;


public class BaseController<TBaseEntity> where TBaseEntity : BaseEntity
{
    protected readonly BaseService<TBaseEntity> _entityService;
    protected readonly string _entityName = typeof(TBaseEntity).Name;

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
            catch (InvalidConsoleInputException e)
            {
                Console.WriteLine(e);
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private void ListEntityMembers()
    {
        var members = _entityService.GetAll().Result;
        if (members.Count == 0)
        {
            Console.WriteLine($"\n\t\t\tNo {_entityName}'s found !!!!\n");
            return;
        }

        Console.WriteLine($"\nList of {_entityName}'s:");
        foreach (var entity in members)
        {
            Console.WriteLine(entity);
        }
    }

    protected virtual void AddEntityMember()
    {
        Console.WriteLine($"\nEnter {_entityName} Details:");

        // todo: has to be async
        // Console.WriteLine(" member added successfully.");
    }

    protected virtual void UpdateEntityMember()
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

    protected T GetFromConsole<T>(string message)
    {
        var maxTries = 5;
        while (maxTries > 0)
        {
            Console.Write($"\nEnter {message} :");
            var value = Console.ReadLine();
            try
            {
                if (typeof(T) == typeof(int))
                {
                    if (int.TryParse(value, out int intValue))
                        return (T)(object)intValue;
                }
                else if (typeof(T) == typeof(double))
                {
                    if (double.TryParse(value, out double doubleValue))
                        return (T)(object)doubleValue;
                }
                else if (typeof(T) == typeof(string))
                {
                    if (value.Length > 0)
                        return (T)(object)value;

                    throw new InvalidConsoleInputException("String value cannot be empty");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Invalid Entry for the type {typeof(T)}");
                Console.WriteLine("Enter again!!");
            }
            maxTries--;
            Console.WriteLine($"\t\t\tTries left {maxTries}!!!");
        }

        throw new InvalidConsoleInputException("You are exhausted with max number of tries");
    }
}