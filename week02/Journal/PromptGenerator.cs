using System;
using System.Collections;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "What was the best part of my day?",
        "What was the bad part of my day?",
        "How did I see the hand of the Lord in my life?",
        "What did I learn today that I can apply to my life?",
        "What did I do today to improve my gifts?",
        "What did I study?",
        "What did I learn from my study today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}