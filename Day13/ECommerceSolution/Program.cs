using ECommerceApp.Controllers;
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
    
    static async Task Main(string[] args)
    {
        ProductController productController = new ProductController(new ProductService(new ProductRepository()));
        productController.Run();
    }
}