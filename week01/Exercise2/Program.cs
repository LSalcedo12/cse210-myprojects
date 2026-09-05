using System;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main()
    {

        // 1. Ask the user for their grade percentage, then write 
        // a series of if, else if, else statements to print out 
        // the appropriate letter grade. (At this point, you'll have a 
        // separate print statement for each grade letter in the appropriate block.)

        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percentage = int.Parse(answer);

        // variable to save the letter
        string letter = "";
        string sign = "";

        // make the percentaje
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch Challenge
        int lastDigit = percentage % 10;
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit <= 3)
        {
             sign = "-";
        }
        else
        {
            sign = "";
        }
        Console.WriteLine($"Your grade percentage is: {letter}{sign}");

         if (percentage >= 70)
        {
            Console.WriteLine("Congratulation, you pass the course!");
        }
        else
        {
            Console.WriteLine("You didn't pass the couse, keep trying next block!");
        }

    }
}