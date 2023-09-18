using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (var entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}: {entry.Text}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        entries.Clear(); // Clear existing entries before loading from the file

        using (StreamReader reader = new StreamReader(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Split the line into date and text based on the separator ": "
                string[] parts = line.Split(new[] { ": " }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    string date = parts[0];
                    string text = parts[1];
                    Entry entry = new Entry(date, text);
                    entries.Add(entry);
                }
            }
        }
    }
}
