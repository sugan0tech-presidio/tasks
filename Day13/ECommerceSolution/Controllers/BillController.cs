using ECommerceApp.Entities;
using ECommerceApp.Services;

namespace ECommerceApp.Controllers;

public class BillController : BaseController<Bill>
{
    private readonly BillService BillService;
    private readonly User _user;

    public BillController(BaseService<Bill> entityService) : base(entityService)
    {
        BillService = entityService as BillService;
    }

    public void Run()
    {
        Console.WriteLine($"Welcome to Billing Management System!");
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        while (true)
        {
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


    private void CheckoutBill()
    {
        var cart = BillService.CheckoutUser(_user);
        Console.WriteLine("Generated Bill");
        Console.WriteLine(cart);
    }
}