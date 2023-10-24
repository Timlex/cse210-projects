// Program 4: Polymorphism with Exercise Tracking. 
// This program simulates tracking exercise activities such as Running, Stationary Bicycles, and Swimming using a base Activity class and derived classes.
// This code demonstrates how polymorphism allows you to create a list of different activity types and call their methods, even though they have different implementations.


using System;
using System.Collections.Generic;

class Activity
{
    public DateTime Date { get; private set; }
    public int LengthInMinutes { get; private set; }

    public Activity(DateTime date, int lengthInMinutes)
    {
        Date = date;
        LengthInMinutes = lengthInMinutes;
    }

    public virtual double CalculateDistance()
    {
        // Base class provides no specific distance calculation
        return 0;
    }

    public virtual double CalculateSpeed()
    {
        // Base class provides no specific speed calculation
        return 0;
    }

    public virtual string GetPace()
    {
        // Base class provides no specific pace calculation
        return "N/A";
    }

    public virtual string GetSummary()
    {
        return $"{Date:d} {GetType().Name} ({LengthInMinutes} min)";
    }
}

class Running : Activity
{
    public double DistanceInMiles { get; private set; }

    public Running(DateTime date, int lengthInMinutes, double distanceInMiles)
        : base(date, lengthInMinutes)
    {
        DistanceInMiles = distanceInMiles;
    }

    public override double CalculateDistance()
    {
        return DistanceInMiles;
    }

    public override double CalculateSpeed()
    {
        return DistanceInMiles / (LengthInMinutes / 60.0); // Speed in miles per hour
    }

    public override string GetPace()
    {
        double pace = LengthInMinutes / DistanceInMiles;
        return TimeSpan.FromMinutes(pace).ToString(@"m\:ss") + " min per mile";
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {DistanceInMiles} miles, Speed: {CalculateSpeed():F2} mph, Pace: {GetPace()}";
    }
}

class StationaryBicycles : Activity
{
    public double SpeedInMph { get; private set; }

    public StationaryBicycles(DateTime date, int lengthInMinutes, double speedInMph)
        : base(date, lengthInMinutes)
    {
        SpeedInMph = speedInMph;
    }

    public override double CalculateSpeed()
    {
        return SpeedInMph;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Speed: {SpeedInMph:F2} mph";
    }
}

class Swimming : Activity
{
    public int Laps { get; private set; }

    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        Laps = laps;
    }

    public override double CalculateDistance()
    {
        return Laps * 50 / 1000.0; // Convert laps to kilometers
    }

    public override double CalculateSpeed()
    {
        return CalculateDistance() / (LengthInMinutes / 60.0); // Speed in kilometers per hour
    }

    public override string GetPace()
    {
        double pace = LengthInMinutes / CalculateDistance();
        return TimeSpan.FromMinutes(pace).ToString(@"m\:ss") + " min per km";
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {CalculateDistance():F2} km, Speed: {CalculateSpeed():F2} kph, Pace: {GetPace()}";
    }
}

class Program
{
    static void Main()
    {
        // Create sample activities of each type
        Running runningActivity = new Running(DateTime.Now, 30, 3.0); // 3 miles in 30 minutes
        StationaryBicycles cyclingActivity = new StationaryBicycles(DateTime.Now, 45, 15.0); // 15 mph for 45 minutes
        Swimming swimmingActivity = new Swimming(DateTime.Now, 60, 40); // 40 laps in 60 minutes

        // Create a list to store activities
        List<Activity> activities = new List<Activity>
        {
            runningActivity,
            cyclingActivity,
            swimmingActivity
        };

        // Display summaries of all activities
        Console.WriteLine("Exercise Tracking Summary:");
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
