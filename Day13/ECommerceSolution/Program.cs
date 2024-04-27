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
    private static readonly CartService CartService = new CartService(new CartRepository(), new ProductRepository());
    private static readonly UserService UserService = new UserService(new UserRepository());
    private static readonly BillService BillService = new BillService(CartService, UserService);
    
    
    static async Task Main(string[] args)
    {
        seed();
        ProductController productController = new ProductController(ProductService);
        productController.Run();
    }


    public static void seed()
    {
        Product a = new Product("pencil", 50, 5);
        a.Brand = "Natraj";
        a.Category = "Stationary";
        
        Product b = new Product("powder", 10, 50);
        b.Brand = "Ponds";
        b.Category = "Makeup";
        
        Product c = new Product("Pillow", 15,500);
        c.Brand = "Rolex";
        c.Category = "Cussion";

        ProductService.Add(a);
        ProductService.Add(b);
        ProductService.Add(c);

        User u1 = new User("sugan", "sugan@mail.com", "NY, salem");
        User u2 = new User("supramani", "mani_83@mail.com", "Eyb, San FB");
        
        UserService.Add(u1);
        UserService.Add(u2);
        
        Console.WriteLine("Seeds completed");
    }
}