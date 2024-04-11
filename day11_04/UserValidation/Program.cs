namespace UserValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name:");
            string name = Console.ReadLine()??"";
            Console.WriteLine($"{name} length is {getSize(name)}");

            int maxTry = 3;
            while(maxTry > 0 )
            {
                Console.WriteLine("Enter the name:");
                name = Console.ReadLine() ?? "";
                Console.WriteLine("Enter the password:");
                string password = Console.ReadLine()??"";
                if (auth(name, password))
                {
                    Console.WriteLine("Auth successful");
                    Console.WriteLine($"Welcome {name}!!");
                    return;
                }
                else
                {
                    maxTry--;
                    Console.WriteLine($"You only have {maxTry} attempts left.");
                }

            }
            Console.WriteLine("You are out of try!!!, Try after sometime.");
        }

        static bool auth(string username, string password)
        {
            return username == "ABC" && password == "123";
        }
        static int getSize(string name)
        {
            return name.Length;
        }
    }
}
