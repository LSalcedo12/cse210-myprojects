using System;

// I just add the option of the mood, because its easy to see how we felt the day.

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Load the journal from a file");
        Console.WriteLine("4. Save the journal to a file");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");

        string choice = Console.ReadLine();
        Console.WriteLine();

        switch (choice)
            {
                case "1":
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry
                {
                    _date = date,
                    _promptText = prompt,
                    _entryText = response
                };

                theJournal.AddEntry(newEntry);
                Console.WriteLine("Entry recorded!\n");
                break;

                case "2":
                    theJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    theJournal.LoadFromFile(loadFile);
                    break;

                case"4":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    theJournal.SaveToFile(saveFile);
                    break;

                case"5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}