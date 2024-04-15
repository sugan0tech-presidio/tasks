﻿namespace BullAndCow;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\t\tWelcome to the Cows and Bulls Game!!\nRules: word should be in 4 characters only consists of alphabets\n");

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
        var bullsCount = 0;
        var cowsCount = 0;
        var freq = new int[26];
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