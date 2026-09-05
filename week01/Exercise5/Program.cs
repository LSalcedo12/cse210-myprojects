using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        // Asks for and returns the user's name (as a string)
        string userName = PromptUserName();

        //Asks for and returns the user's favorite number (as an integer)
        int number = PromptUserNumber();

        // Accepts an integer as a parameter and returns 
        // that number squared (as an integer)
        int square = SquareNumber(number);

        //Accepts the user's name and the squared number and displays them.
        DisplayResult(userName, square);
    }

    // Displays the message, "Welcome to the Program!"
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please Enter your name: ");
        string text = Console.ReadLine();
        return text;
    }

    static int PromptUserNumber()
    {
        Console.Write("E=Please enter your favorite number: ");
        int text = int.Parse(Console.ReadLine());
        return text;
    }

    static int SquareNumber(int number)
    {
        int result = number * number;
        return result;
    }

    static void DisplayResult(string name, int square)
    {Console.WriteLine($"{name}, the square of your number is {square}");
    }
}