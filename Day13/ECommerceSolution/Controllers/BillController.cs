using ECommerceApp.Entities;
using ECommerceApp.Services;

namespace ECommerceApp.Controllers;

public class BillController : BaseController<Bill>
{
    private readonly BillService BillService;
    private readonly UserService UserService;
    private User user;

    public BillController(BaseService<Bill> entityService, UserService userService) : base(entityService)
    {
        BillService = entityService as BillService;
        UserService = userService;
    }

    public void Run()
    {
        if (AddUser())
        {
            Console.WriteLine($"Successfully Logged as {user.Name}");
            ShowMainMenu();
        }
    }

    private void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("Welcome to Billing Management System!");
            Console.WriteLine("\nBilling's Menu:");
            Console.WriteLine("1. Checkout Bill");
            Console.WriteLine("2. Clear Console");
            Console.WriteLine("3. exit to Main Menu");


            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        CheckoutBill();
                        break;
                    case "2":
                        Console.Clear();
                        break;
                    case "3":
                        user = null;
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

    private bool AddUser()
    {
        var id = GetFromConsole<int>("User Id");
        try
        {
            user = UserService.GetByIdAsync(id).Result;
            return true;
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
        }

        return false;
    }

    private void CheckoutBill()
    {
        var cart = BillService.CheckoutUser(user).Result;
        Console.WriteLine("Generated Bill");
        Console.WriteLine(cart);
    }
}