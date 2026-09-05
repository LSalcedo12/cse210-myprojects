using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
             Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;
        
        
            // Asking the user for the magic number.
            Console.Write("What is your magic number? ");
            magicNumber = int.Parse(Console.ReadLine());

        while (guess != magicNumber)
        {
            // Ask the user guess.
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            guessCount++;

            // Determine if the user needs to guess higher or lower
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");

            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
                
            }

        Console.WriteLine($"It took you {guessCount} guesses.");
        
        Console.Write("Do you want to play again? ");
        playAgain = Console.ReadLine();
        Console.WriteLine();
    }
    Console.WriteLine("Thanks for playing");
}
}