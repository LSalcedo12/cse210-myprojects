using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine($"{goal.GetType().Name}:{goal.GetStringRepresentation()}");
            }
        }
        Console.WriteLine("Goals saved succesfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string [] lines = System.IO.File.ReadAllLines(filename);

            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] details = parts[1].Split(',');

                if (goalType == "SimpleGoal")
                {
                    string name = details[0].Trim();
                    string description = details[1].Trim();
                    string points = details[2].Trim();
                    bool isComplete = bool.Parse(details[3].Trim());

                    SimpleGoal goal = new SimpleGoal(name, description, points);
                    if (isComplete)
                    {
                        goal.RecordEvent();
                    }
                    _goals.Add(goal);
                }
                else if (goalType == "ChecklistGoal")
                {
                    string name = details[0];
                    string description = details[1];
                    string points = details[2];
                    int bonus = int.Parse(details[3]);
                    int target = int.Parse(details[4]);
                    int amountCompleted = int.Parse(details[5]);

                    ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);

                    for (int j = 0; j < amountCompleted; j++)
                    {
                        goal.RecordEvent();
                    }
                    _goals.Add(goal);
                }
            }
            Console.WriteLine("Goals loaded succesfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine();
            Console.WriteLine($"You have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // CreateGoal();
                     Console.WriteLine("The types of Goals are:");
                Console.WriteLine("  1. Simple Goal");
                Console.WriteLine("  2. Eternal Goal");
                Console.WriteLine("  3. Checklist Goal");
                Console.Write("Which type of goal would you like to create? ");
                string goalType = Console.ReadLine();

                Console.Write("What is the name of your goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                string points = Console.ReadLine();

                if (goalType == "1")
                {
                    SimpleGoal goal = new SimpleGoal(name, description, points);
                    _goals.Add(goal);
                }
                else if (goalType == "2")
                {
                    EternalGoal goal = new EternalGoal(name, description, points);
                    _goals.Add(goal);
                }
                else if (goalType == "3")
                {
                    Console.Write("What is the target amount of times for this goal? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());

                    ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                    _goals.Add(goal);
                }
                break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    // RecordEvent();
                    ListGoalDetails(); 
                    Console.Write("Which goal did you accomplish? ");
                    string input = Console.ReadLine();
                    
                    
                    if (int.TryParse(input, out int goalNumber))
                    {
                        int index = goalNumber -1;

                        if (index >= 0 && index < _goals.Count)
                        {
                            _goals[index]. RecordEvent();
                            _score += (_goals[index].GetPoints());
                            Console.WriteLine($"Congratulations! You have earned points!");
                        }
                        else
                       {
                            Console.WriteLine("Invalid goal selection.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent(int index)
    {
        Goal goal = _goals[index];
        goal.RecordEvent();
    }
}