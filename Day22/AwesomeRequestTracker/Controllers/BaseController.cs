using AwesomeRequestTracker.Exceptions;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Serivces;

namespace AwesomeRequestTracker.Controllers;

public abstract class BaseController<TBaseEntity> where TBaseEntity : BaseEntity
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
        if (AuthService.IsLogged)
            ShowMainMenu();
    }

    public abstract void ShowMainMenu();


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

    /// <summary>
    /// Special tool utility for handeling console level input V1 ( from day 9 )
    /// has default max tries of 5
    /// </summary>
    /// <param name="message">content to displayed for input</param>
    /// <typeparam name="T">can be of int, float and string types</typeparam>
    /// <returns>generated & validated type T</returns>
    /// <exception cref="InvalidConsoleInputException">If the console input mismatches</exception>
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
                else if (typeof(T) == typeof(float))
                {
                    if (float.TryParse(value, out float floatValue))
                        return (T)(object)floatValue;
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