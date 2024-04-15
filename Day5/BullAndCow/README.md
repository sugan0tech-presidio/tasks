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
        Console.WriteLine("\t\tWelcome to the Cows and Bulls Game!!\n" +
                          "Rule 1: word should be in 4 characters only consists of alphabets\n" +
                          "Rule 2: cows represents no of exact matched words & bull represents misplaced character\n");

        var secret = "golf";
        var program = new Program();
        do
        {
            Console.Write("Enter your guess\t:");
            var guess = (Console.ReadLine()??string.Empty).ToLower();
            if (guess.Length != 4)
            {
                Console.WriteLine("Please enter a valid guess\n");
                continue;
                
            }
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
        var cowCount = 0;
        var bullCount = 0;
        var freq = new int[26];
        var n = secret.Length;
        
        for(int i = 0; i < n; i++){
            if(secret[i] == guess[i])
                cowCount++;
            else
                freq[secret[i] - 'a']++;
        }
        
        for(int i = 0; i < n; i++){
            if(secret[i] != guess[i]){
                if(freq[guess[i] - 'a'] > 0){
                    bullCount++;
                    freq[guess[i] - 'a']--;
                }
            }
        }
        
        return $"bulls - {bullCount}, cows - {cowCount}";

    }
}
```

output
---
```text
                Welcome to the Cows and Bulls Game!!
Rule 1: word should be in 4 characters only consists of alphabets
Rule 2: cows represents no of exact matched words & bull represents misplaced character

Enter your guess        :wolf
The hint is     :       bulls - 0, cows - 3

Enter your guess        :olfe
The hint is     :       bulls - 3, cows - 0

Enter your guess        :sidi2d
Please enter a valid guess

Enter your guess        :golf
Whola that's a fine guess

```

Leetcode counter part
---
[submission link](https://leetcode.com/submissions/detail/1232932184/)
