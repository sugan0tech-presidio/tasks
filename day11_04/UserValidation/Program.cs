namespace UserValidation
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter 1 for sample user Auth, 2 for least vowels frequency problem");
            var options = Console.ReadLine();
            if (options == "1")
            {
                Console.WriteLine("Enter the name:");
                string name = Console.ReadLine() ?? "";
                Console.WriteLine($"{name} length is {GetSize(name)}");

                int maxTry = 3;
                while (maxTry > 0)
                {
                    Console.WriteLine("Enter the name:");
                    name = Console.ReadLine() ?? "";
                    Console.WriteLine("Enter the password:");
                    string password = Console.ReadLine() ?? "";
                    if (Auth(name, password))
                    {
                        Console.WriteLine("Auth successful");
                        Console.WriteLine($"Welcome {name}!!");
                        return;
                    }

                    maxTry--;
                    Console.WriteLine($"You only have {maxTry} attempts left.");

                }
                Console.WriteLine("You are out of try!!!, Try after sometime.");
            }
            else if( options == "2")
            {
                var vowels = new Vowels();
                Console.WriteLine("Enter the comma seperated string for words with least vowels");
                var str = Console.ReadLine();
                Console.WriteLine(str);
                var res = vowels.GetLeastWords(str ?? "");
                Console.WriteLine("hereee");
                foreach (var item in res.Keys)
                {
                    Console.WriteLine(item);
                    Console.WriteLine($"count {res[item]}");
                }
            }
            Console.WriteLine("Thank you!!!");

        }

        static bool Auth(string username, string password)
        {
            return username == "ABC" && password == "123";
        }
        static int GetSize(string name)
        {
            return name.Length;
        }
    }
}
