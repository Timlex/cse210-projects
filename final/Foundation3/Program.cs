// Program 3: Inheritance with Event Planning. 
// This program simulates an event planning system with base and derived classes for different types of events: Lectures, Receptions, and Outdoor Gatherings.
// This code demonstrates how inheritance is used to avoid duplicating shared attributes and methods while allowing each event type to have its own unique properties and behavior. 


using System;

class Event
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public TimeSpan Time { get; private set; }
    public Address EventAddress { get; private set; }

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        EventAddress = address;
    }

    public virtual string GenerateStandardMessage()
    {
        return $"Event: {Title}\nDescription: {Description}\nDate: {Date:d}\nTime: {Time:h\\:mm tt}\nAddress: {EventAddress.GetFormattedAddress()}";
    }
}

class Lecture : Event
{
    public string SpeakerName { get; private set; }
    public int Capacity { get; private set; }

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speakerName, int capacity)
        : base(title, description, date, time, address)
    {
        SpeakerName = speakerName;
        Capacity = capacity;
    }

    public override string GenerateFullMessage()
    {
        return $"{base.GenerateStandardMessage()}\nSpeaker: {SpeakerName}\nCapacity: {Capacity} attendees";
    }
}

class Reception : Event
{
    public string RsvpEmail { get; private set; }

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        RsvpEmail = rsvpEmail;
    }

    public override string GenerateFullMessage()
    {
        return $"{base.GenerateStandardMessage()}\nRSVP Email: {RsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    public string WeatherInfo { get; private set; }

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherInfo)
        : base(title, description, date, time, address)
    {
        WeatherInfo = weatherInfo;
    }

    public override string GenerateFullMessage()
    {
        return $"{base.GenerateStandardMessage()}\nWeather: {WeatherInfo}";
    }
}

class Address
{
    public string StreetAddress { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    public Address(string streetAddress, string city, string state, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        Country = country;
    }

    public string GetFormattedAddress()
    {
        return $"{StreetAddress}, {City}, {State}, {Country}";
    }
}

class Program
{
    static void Main()
    {
        // Create just a sample events of each type
        Lecture lectureEvent = new Lecture("Tech Talk", "Latest tech trends", DateTime.Now, new TimeSpan(14, 0, 0), new Address("123 Main St", "Cityville", "CA", "USA"), "John Doe", 50);
        Reception receptionEvent = new Reception("Holiday Party", "Join us for a festive evening", DateTime.Now, new TimeSpan(19, 0, 0), new Address("456 Elm St", "Townsville", "NY", "USA"), "rsvp@example.com");
        OutdoorGathering outdoorEvent = new OutdoorGathering("Picnic in the Park", "Enjoy the outdoors", DateTime.Now, new TimeSpan(12, 0, 0), new Address("789 Oak St", "Villageville", "TX", "USA"), "Sunny with a high of 75°F");

        // Generate and display marketing messages for each event
        Console.WriteLine("Lecture Event:");
        Console.WriteLine(lectureEvent.GenerateFullMessage());

        Console.WriteLine("\nReception Event:");
        Console.WriteLine(receptionEvent.GenerateFullMessage());

        Console.WriteLine("\nOutdoor Gathering Event:");
        Console.WriteLine(outdoorEvent.GenerateFullMessage());
    }
}
