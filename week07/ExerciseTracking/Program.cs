using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running run = new Running("03 Nov 2022", 30, 3.0);
        Cycling cycle = new Cycling("03 Nov 2022", 45, 15.0);
        Swimming swim = new Swimming("03 Nov 2022", 40, 20);

        activities.Add(run);
        activities.Add(cycle);
        activities.Add(swim);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

    }
}