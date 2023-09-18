using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"Prompt: {prompt}");
                        Console.Write("Enter your response: ");
                        string response = Console.ReadLine();
                        journal.AddEntry(new Entry(prompt, response, DateTime.Now));
                        break;
                    case 2:
                        journal.DisplayJournal();
                        break;
                    case 3:
                        Console.Write("Enter the file name to save: ");
                        string saveFileName = Console.ReadLine();
                        journal.SaveJournalToFile(saveFileName);
                        break;
                    case 4:
                        Console.Write("Enter the file name to load: ");
                        string loadFileName = Console.ReadLine();
                        journal.LoadJournalFromFile(loadFileName);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveJournalToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date.ToString("yyyy-MM-dd HH:mm:ss")}\n{entry.Prompt}\n{entry.Response}\n");
            }
        }
    }

    public void LoadJournalFromFile(string fileName)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(fileName);

        for (int i = 0; i < lines.Length; i += 3)
        {
            DateTime date = DateTime.ParseExact(lines[i], "yyyy-MM-dd HH:mm:ss", null);
            string prompt = lines[i + 1];
            string response = lines[i + 2];
            entries.Add(new Entry(prompt, response, date));
        }
    }
}

class Entry
{
    public string Prompt { get; }
    public string Response { get; }
    public DateTime Date { get; }

    public Entry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date.ToString("yyyy-MM-dd HH:mm:ss")}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}\n");
    }
}

class PromptGenerator
{
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}
