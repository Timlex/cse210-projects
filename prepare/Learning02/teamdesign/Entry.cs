class Entry
{
    public string Date { get; }
    public string Text { get; }

    public Entry(string date, string text)
    {
        Date = date;
        Text = text;
    }

    public void Display()
    {
        Console.WriteLine($"{Date}: {Text}");
    }
}
