using System;
using System.Collections.Generic;
using System.IO;

// Base class for goals
abstract class Goal
{
    public string Name { get; set; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name)
    {
        Name = name;
        IsCompleted = false;
    }

    // Method to record an event for the goal
    public virtual void RecordEvent()
    {
        IsCompleted = true;
    }

    // Abstract method to calculate the score for the goal
    public abstract int CalculateScore();
}

// Simple goal class
class SimpleGoal : Goal
{
    public int Points { get; private set; }

    public SimpleGoal(string name, int points) : base(name)
    {
        Points = points;
    }

    public override int CalculateScore()
    {
        return IsCompleted ? Points : 0;
    }
}

// Eternal goal class
class EternalGoal : Goal
{
    public int PointsPerEvent { get; private set; }

    public EternalGoal(string name, int pointsPerEvent) : base(name)
    {
        PointsPerEvent = pointsPerEvent;
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
    }

    public override int CalculateScore()
    {
        return IsCompleted ? PointsPerEvent : 0;
    }
}

// Checklist goal class
class ChecklistGoal : Goal
{
    public int PointsPerEvent { get; private set; }
    public int TargetCount { get; private set; }
    private int eventsCompleted;

    public ChecklistGoal(string name, int pointsPerEvent, int targetCount) : base(name)
    {
        PointsPerEvent = pointsPerEvent;
        TargetCount = targetCount;
        eventsCompleted = 0;
    }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            eventsCompleted++;
            if (eventsCompleted >= TargetCount)
            {
                IsCompleted = true;
            }
        }
    }

    public override int CalculateScore()
    {
        return IsCompleted ? (PointsPerEvent * TargetCount) : (PointsPerEvent * eventsCompleted);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();

        // More will be add to some goals
        goals.Add(new SimpleGoal("Run a marathon", 1000));
        goals.Add(new EternalGoal("Read scriptures", 100));
        goals.Add(new ChecklistGoal("Attend the temple", 50, 10));

        // Record events for goals
        goals[0].RecordEvent(); // Completing a marathon
        goals[2].RecordEvent(); // Attending the temple once
        goals[2].RecordEvent(); // Attending the temple twice

        // Display scores
        Console.WriteLine("Goal Scores:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine($"{goal.Name}: {goal.CalculateScore()} points");
        }

        // Save and load goals (my future implementation)
        SaveGoalsToFile(goals, "goals.txt");
        List<Goal> loadedGoals = LoadGoalsFromFile("goals.txt");
    }

    // Method to save goals to a file
    static void SaveGoalsToFile(List<Goal> goals, string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Goal goal in goals)
            {
                outputFile.WriteLine($"{goal.GetType().Name}:{goal.Name}:{goal.IsCompleted}");
            }
        }
    }

    // Method to load goals from a file
    static List<Goal> LoadGoalsFromFile(string filename)
    {
        List<Goal> loadedGoals = new List<Goal>();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(':');
            string goalType = parts[0];
            string goalName = parts[1];
            bool isCompleted = bool.Parse(parts[2]);

            switch (goalType)
            {
                case "SimpleGoal":
                    loadedGoals.Add(new SimpleGoal(goalName, 0));
                    break;
                case "EternalGoal":
                    loadedGoals.Add(new EternalGoal(goalName, 0));
                    break;
                case "ChecklistGoal":
                    loadedGoals.Add(new ChecklistGoal(goalName, 0, 0));
                    break;
                default:
                    break;
            }

            loadedGoals[loadedGoals.Count - 1].IsCompleted = isCompleted;
        }

        return loadedGoals;
    }
}
