namespace GreatestNum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Values, give negative to end & get the result");
            double max = 0;
            double avgDivBySeven = 0;
            int avgDivBySevenCount = 0;
            while (true)
            {
                Console.WriteLine("val:");
                double input = double.Parse(Console.ReadLine()??"0");
                if(input <= 0)
                {
                    break;
                }
                if(input%7 == 0)
                {
                    avgDivBySeven += input;
                    avgDivBySevenCount++;
                }
                max = input > max ? input : max;
            }
            Console.WriteLine($"The Greatest Value of All Time is : {max}");
            Console.WriteLine($"The avg of nums divsible by 7 is : {avgDivBySeven / avgDivBySevenCount}");
        }
    }
}
