### Code
```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the Card sequence : ");
        var charSequenceString = Console.ReadLine()??"4477468343113002";
        Console.WriteLine(ValidateCreditCardNumber(charSequenceString));
    }

    private static bool ValidateCreditCardNumber(string number)
    {
        var sum = 0;
        var alternate = false;
        int n = 16;

        if (number.Length != n)
        {
            Console.WriteLine("card number should be equal to 16"); 
            return false;
        }

        for (var i = n - 1; i >= 0; i--)
        {
            var digit = number[i] - '0';

            if (alternate)
            {
                digit *= 2;
                if (digit > 9)
                    digit = (digit % 10) + 1;
            }

            sum += digit;
            alternate = !alternate;
        }

        return sum % 10 == 0;
    }

}
```
### output
```
Enter the Card sequence : 5555555555554444
True
Enter the Card sequence : 2838223388223388
False
```
