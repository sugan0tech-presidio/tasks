using ECommerceApp.Controllers;
using ECommerceApp.Entities;
using ECommerceApp.Repositories;
using ECommerceApp.Services;

namespace ECommerceApp;

class Program
{
    async Task<int> GetResultFromDatabaseServer()
    {
        Thread.Sleep(2000);
        return new Random().Next();
    }

    public void PrintNum()
    {
        lock (this) // locks the code so that at a time only one thread can use this block
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"By {Thread.CurrentThread.ManagedThreadId} num: {i}");
                Thread.Sleep(1000);
            }
        }
    }


    private static readonly ProductService ProductService = new ProductService(new ProductRepository());
    private static readonly CartService CartService = new CartService(new CartRepository(), ProductService);
    private static readonly UserService UserService = new UserService(new UserRepository());
    private static readonly BillService BillService = new BillService(new BillRepository(), CartService, UserService);


    static async Task Main(string[] args)
    {
        seed();
        try
        {
            ShowMainMenu();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void ShowMainMenu()
    {
        while (true)
        {
            Task task = Task.Run(() => DisplayOptions());
            task.Wait();
            
            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();


            switch (choice)
            {
                case "1":
                    task = Task.Run(() => new ProductController(ProductService).Run());
                    break;
                case "2":
                    task = Task.Run(() => new CartController(CartService, UserService, ProductService).Run());
                    break;
                case "3":
                    task = Task.Run(() => new UserController(UserService).Run());
                    break;
                case "4":
                    task = Task.Run(() => new BillController(BillService, UserService).Run());
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

            task.Wait();
        }
    }

    private static void DisplayOptions()
    {
        Console.WriteLine("\nWelcome to EKart");
        Console.WriteLine("1. Product Management");
        Console.WriteLine("2. Cart Management");
        Console.WriteLine("3. User Management");
        Console.WriteLine("4. Bill Management");
        Console.WriteLine("5. Clear Console");
        Console.WriteLine("6. exit the application");
    }

    public static void seed()
    {
        Product a = new Product("pencil", 50, 5);
        a.Brand = "Natraj";
        a.Category = "Stationary";

        Product b = new Product("powder", 10, 50);
        b.Brand = "Ponds";
        b.Category = "Makeup";

        Product c = new Product("Pillow", 15, 500);
        c.Brand = "Rolex";
        c.Category = "Cussion";

        ProductService.AddAsync(a);
        ProductService.AddAsync(b);
        ProductService.AddAsync(c);

        User u1 = new User("sugan", "sugan@mail.com", "NY, salem");
        User u2 = new User("supramani", "mani_83@mail.com", "Eyb, San FB");

        UserService.AddAsync(u1);
        UserService.AddAsync(u2);

        Console.WriteLine("Seeds completed");
    }
}