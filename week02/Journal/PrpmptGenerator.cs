using System;
using System.Collections;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "How did I felt today?",
        "What was the best part of my day?",
        "what was the bad part of my day?",
        "How did I see the hand of the Lord in my life?",
        "What did I learn today that i can apply to my life?",
        "What did I do today to improve my gifts?",
        "What did I studied today?",
        "What did I learn from my study today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}