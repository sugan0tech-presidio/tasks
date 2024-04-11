namespace GreatestNum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Values, give negative to end & get the result");
            double max = 0;
            while (true)
            {
                Console.WriteLine("val:");
                double input = double.Parse(Console.ReadLine()??"0");
                if(input <= 0)
                {
                    break;
                }
                max = input > max ? input : max;
            }
            Console.WriteLine($"The Greatest Value of All Time is : {max}");
        }
    }
}
