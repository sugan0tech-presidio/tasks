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
        var program = new Program();
        var number = await program.GetResultFromDatabaseServer();
        Console.WriteLine($"from server {number}");
        Console.WriteLine($"from here {new Random().Next()}");
        var number2 = await program.GetResultFromDatabaseServer();
        Console.WriteLine(number2);
        Thread t1 = new Thread(program.PrintNum);
        Thread t2 = new Thread(program.PrintNum);
        t1.Start();
        t2.Start();
    }
}