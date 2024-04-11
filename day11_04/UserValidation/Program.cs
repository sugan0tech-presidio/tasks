namespace UserValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 for sample user Auth, 2 for least vowels frequence problem");
            var options = Console.ReadLine();
            if (options == "1")
            {
                Console.WriteLine("Enter the name:");
                string name = Console.ReadLine() ?? "";
                Console.WriteLine($"{name} length is {getSize(name)}");

                int maxTry = 3;
                while (maxTry > 0)
                {
                    Console.WriteLine("Enter the name:");
                    name = Console.ReadLine() ?? "";
                    Console.WriteLine("Enter the password:");
                    string password = Console.ReadLine() ?? "";
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
            else if( options == "2")
            {
                var vowels = new Vowels();
                Console.WriteLine("Enter the comma seperated string for words with least vowels");
                var str = Console.ReadLine();
                var res = vowels.getLeastWords(str ?? "");
                foreach (var item in res.Keys)
                {
                    Console.WriteLine(item);
                    Console.WriteLine($"count {res[item]}");
                }
            }
            Console.WriteLine("Thank you!!!");

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
