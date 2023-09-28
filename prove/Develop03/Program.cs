using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the ScriptureMemorizer class
        ScriptureMemorizer memorizer = new ScriptureMemorizer();

        // Display the scripture with reference
        memorizer.DisplayScripture();

        // Prompt the user to press enter to hide words or type 'quit' to exit
        while (true)
        {
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            else
            {
                // Hide a few words in the scripture and display it again
                memorizer.HideRandomWords();
                memorizer.DisplayScripture();
            }
        }
    }
}

// Class to represent a single word in the scripture
class ScriptureWord
{
    public string Word { get; set; }
    public bool IsHidden { get; set; }

    public ScriptureWord(string word)
    {
        Word = word;
        IsHidden = false;
    }
}

// Class to represent a scripture reference (e.g., "John 3:16" or "Proverbs 3:5-6")
class ScriptureReference
{
    public string Reference { get; private set; }

    public ScriptureReference(string reference)
    {
        Reference = reference;
    }
}

// Class to represent the scripture and manage hiding words
class ScriptureMemorizer
{
    private ScriptureReference reference;
    private List<ScriptureWord> words;

    public ScriptureMemorizer()
    {
        // Initialize the scripture reference and words
        reference = new ScriptureReference("John 3:16");
        words = new List<ScriptureWord>
        {
            new ScriptureWord("For"),
            new ScriptureWord("God"),
            new ScriptureWord("so"),
            new ScriptureWord("loved"),
            new ScriptureWord("the"),
            new ScriptureWord("world,"),
            new ScriptureWord("that"),
            new ScriptureWord("he"),
            new ScriptureWord("gave"),
            new ScriptureWord("his"),
            new ScriptureWord("only"),
            new ScriptureWord("Son,"),
            new ScriptureWord("that"),
            new ScriptureWord("whoever"),
            new ScriptureWord("believes"),
            new ScriptureWord("in"),
            new ScriptureWord("him"),
            new ScriptureWord("should"),
            new ScriptureWord("not"),
            new ScriptureWord("perish"),
            new ScriptureWord("but"),
            new ScriptureWord("have"),
            new ScriptureWord("eternal"),
            new ScriptureWord("life.")
        };
    }

    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine(reference.Reference);
        StringBuilder displayText = new StringBuilder();

        foreach (ScriptureWord word in words)
        {
            if (word.IsHidden)
            {
                // Replace hidden words with underscores
                displayText.Append(new string('_', word.Word.Length));
            }
            else
            {
                displayText.Append(word.Word);
            }
            displayText.Append(' ');
        }

        Console.WriteLine(displayText.ToString());
    }

    public void HideRandomWords()
    {
        Random random = new Random();

        // Get a random count of words to hide (between 1 and 3)
        int countToHide = random.Next(1, 4);

        // Shuffle the list of words
        words = words.OrderBy(word => random.Next()).ToList();

        // Hide the first 'countToHide' words that are not already hidden
        int hiddenCount = 0;
        foreach (ScriptureWord word in words)
        {
            if (!word.IsHidden)
            {
                word.IsHidden = true;
                hiddenCount++;
            }

            if (hiddenCount >= countToHide)
            {
                break;
            }
        }
    }
}
