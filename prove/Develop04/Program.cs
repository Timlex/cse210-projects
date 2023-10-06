using System;
using System.Threading;

// Define a base class for activities
class MindfulnessActivity
{
    protected string activityName;
    protected string description;
    protected int durationInSeconds;

    public MindfulnessActivity(string name, string desc)
    {
        activityName = name;
        description = desc;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {activityName} activity...");
        Console.WriteLine(description);
        Console.Write("Enter the duration (in seconds): ");
        durationInSeconds = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    public void EndActivity()
    {
        Console.WriteLine($"You've completed the {activityName} activity!");
        Console.WriteLine($"Duration: {durationInSeconds} seconds");
        Thread.Sleep(3000); // Pause for 3 seconds
    }
}

// Define a class for the Breathing Activity
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through deep breathing.")
    {
    }

    public void PerformActivity()
    {
        StartActivity();
        for (int i = 0; i < durationInSeconds; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000); // Pause for 1 second
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }
        EndActivity();
    }
}

// Define a class for the Reflection Activity
class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        // more will be added here latter run
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    public void PerformActivity()
    {
        StartActivity();
        Random random = new Random();

        for (int i = 0; i < durationInSeconds;)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            Thread.Sleep(3000); // Pause for 3 seconds

            foreach (string question in reflectionQuestions)
            {
                Console.WriteLine(question);
                Thread.Sleep(3000); // Pause for 3 seconds
            }

            i += reflectionQuestions.Length + 1;
        }

        EndActivity();
    }
}

// Define a class for the Listing Activity
class ListingActivity : MindfulnessActivity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        // more of the listing prompts will be added letter run
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void PerformActivity()
    {
        StartActivity();

        Random random = new Random();
        string prompt = listingPrompts[random.Next(listingPrompts.Length)];

        Console.WriteLine(prompt);
        Thread.Sleep(3000); // Pause for 3 seconds

        Console.WriteLine("Start listing items...");

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < durationInSeconds)
        {
            
        }

        // Calculate the number of items entered
        int numberOfItems = 0; // Calculate this based on user input

        Console.WriteLine($"You've listed {numberOfItems} items.");
        EndActivity();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.PerformActivity();
                    break;
                case 2:
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.PerformActivity();
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.PerformActivity();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid activity.");
                    break;
            }
        }
    }
}
