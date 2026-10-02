using System;
public class BreathingActivity : Activity
{
    // Constructor
    public BreathingActivity() : base("Breathing Activity",
    "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }
    
    //Principal method
    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        //Exactly time registered for the user
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowCountDown(4);
            Console.WriteLine();

            Console.Write("Breathe out...");
            ShowCountDown(6);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}