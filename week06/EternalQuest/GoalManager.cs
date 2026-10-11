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
                outputFile.WriteLine(goal.GetStringRepresentation());
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
            string [] lines = File.ReadAllLines(filename);

            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] details = parts[1].Split(',');

                if (goalType == "simpleGoal")
                {
                    string name = details[0];
                    string description = details[1];
                    string points = details[2];
                    bool isComplete = bool.Parse(details[3]);

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
                    ListGoalDetails(); // Muestra las metas para que el usuario sepa cuál elegir
                    Console.Write("Which goal did you accomplish? ");
                    int index = int.Parse(Console.ReadLine()) - 1; // Restamos 1 porque las listas empiezan en 0
                    
                    // Verificamos que el índice sea válido y registramos el evento
                    if (index >= 0 && index < _goals.Count)
                    {
                        // Llamamos al método RecordEvent de la meta seleccionada
                        // (Asegúrate de sumar los puntos que otorga esa meta a tu _score total)
                        _score += _goals[index].GetPoints(); // (O la lógica que tengas para sumar puntos)
                        _goals[index].RecordEvent();
                        Console.WriteLine($"Congratulations! You have earned points!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid goal selection.");
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