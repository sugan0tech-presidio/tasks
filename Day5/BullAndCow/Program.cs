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