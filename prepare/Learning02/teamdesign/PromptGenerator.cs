using System;
using System.Collections.Generic;

class PromptGenerator
{
    private List<string> prompts = new List<string>
    {
        "Write about your favorite childhood memory.",
        "Describe a place you've always wanted to visit.",
        "What are your goals for the next year?",
        // Add more prompts here
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}
