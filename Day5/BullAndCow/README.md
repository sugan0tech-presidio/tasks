# Problem 2
--- 
Description
---
```
Create an application that will allow the user to play cow an bull(only for 4 char word)
Same char same position - cow
Same char diff position - bull
Example - If the word is - golf
Start the guess
heap
cows - 0, bulls - 0
kite
cows - 0, bulls -0
girl
cows - 1, bulls -1
like
cows -0, bulls 1
milk
cows -1, bull -0
goat
cows -2, bulls - 0
gold
cows -3, bulls-0
golf
cows -4, bulls -0
Congrats!!! you won!!!!!
```

Solution
---
```csharp
namespace BullAndCow;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\t\tWelcome to the Cows and Bulls Game!!\n\n");

        var secret = "golf";
        var program = new Program();
        do
        {
            Console.Write("Enter your guesst\t:");
            var guess = (Console.ReadLine()??string.Empty).ToLower();
            if (guess == secret)
            {
                Console.WriteLine("Whola that's a fine guess");
                return;
            }
                
            Console.WriteLine($"The hint is\t:\t{program.GetHint(secret, guess)}\n");
        } while (true);
    }

    string GetHint(string secret, string guess)
    {
        var bullsCount = 0;
        var cowsCount = 0;
        int[] freq = new int[26];
        var n = secret.Length;
        
        for(int i = 0; i < n; i++){
            if(secret[i] == guess[i])
                bullsCount++;
            else
                freq[secret[i] - 'a']++;
        }
        
        for(int i = 0; i < n; i++){
            if(secret[i] != guess[i]){
                if(freq[guess[i] - 'a'] > 0){
                    cowsCount++;
                    freq[guess[i] - 'a']--;
                }
            }
        }
        
        return $"cows - {cowsCount}, bulls - {bullsCount}";

    }
}
```

output
---
```text
                Welcome to the Cows and Bulls Game!!


Enter your guess        :wolf
The hint is     :       cows - 0, bulls - 3

Enter your guess        :eolf
The hint is     :       cows - 0, bulls - 3

Enter your guess        :cglf
The hint is     :       cows - 1, bulls - 2

Enter your guess        :golf
Whola that's a fine guess

```

Leetcode counter part
---
[submission link](https://leetcode.com/submissions/detail/1232932184/)