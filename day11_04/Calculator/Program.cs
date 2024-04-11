using System.Transactions;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The calculator!");
            while(true)
            {
                Console.WriteLine("num1: ");
                double a = Convert.ToDouble(Console.ReadLine()??"0");
                Console.WriteLine("num2: ");
                double b = Convert.ToDouble(Console.ReadLine()??"0");
                Console.WriteLine("Enter he option +,-,/,*,% and else to exit");
                char opt = Convert.ToChar(Console.ReadLine()??"e");

                switch (opt)
                {
                    case '+':
                        Console.WriteLine($"sum is {add(a, b)}");
                        break;
                    case '-':
                        Console.WriteLine($"sub is {sub(a, b)}");
                        break;
                    case '*':
                        Console.WriteLine($"multiplication is {multiply(a, b)}");
                        break;
                    case '/':
                        Console.WriteLine($"division is {divide(a, b)}");
                        break;
                    case '%':
                        Console.WriteLine($"remainder is {remainder(a, b)}");
                        break;
                    default:
                        Console.WriteLine("Thank you!!!");
                        return;
                }


            }
        }

        static double add(double a,  double b)
        {
            return a + b;
        }

        static double sub(double a, double b)
        {
            return a - b;
        }
        
        static double multiply(double a, double b)
        {
            return a * b;
        }
        static double divide(double a, double b)
        {
            return a / b;
        }

        static double remainder(double a, double b)
        {
            return a % b;
        }
    }
}
