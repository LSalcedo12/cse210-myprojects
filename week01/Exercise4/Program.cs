using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");


    while (true)
    {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        // If the user type 0 stop the program
        if (number == 0)
            {
                break;
            }
            
            // Add the number if it's not 0
            numbers.Add(number);
    }

    // Compute the sum, or total, of the numbers in the list.
    int sum = 0;
    foreach (int number in numbers)
        {
            sum = sum + number;
        }
    // Compute the average of the numbers in the list.
    float average = (float)sum / numbers.Count;

    // Find the maximum, or largest, number in the list.
    int max = numbers[0];
    foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
    // Print results
    Console.WriteLine($"The sum is: {sum}");
    Console.WriteLine($"The average is: {average}");
    Console.WriteLine($"The largest number is: {max} ");

    int smallestPositive = int.MaxValue;

    foreach (int number in numbers)
    {
        if (number > 0)
        {
            if (number < smallestPositive)
                {
                    smallestPositive = number;
                }
        }
        }

        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}