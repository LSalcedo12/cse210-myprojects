using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// EXCEEDING REQUIREMENTS:
// 1. Stretch Challenge: The HideRandomWords method only selects from words that are not already hidden.
// 2. Multiple Scripture Support: Instead of a single hardcode scripture, this program storeas a library
//    of scriptures and randomly selects one for the user to memorize each time the program runs.

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool isHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Replace by underscores (_)
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }

}
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    //Store a scripture, including both the reference (for example "John 3:16")
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    // Accommodate scriptures with multiple verses, such as "Proverbs 3:5-6".
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}: {_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}

// Display the complete scripture, including the reference and the text.
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Divide the text 
        string[] splitwords = text.Split(' ');
        foreach (string wordText in splitwords)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numbertoHide)
    {
        Random random = new Random();

        // G\et only the words that are not hidden
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if(!word.isHidden())
            {
                visibleWords.Add(word);
            }
        }

        // select random words 
        for (int i = 0; i < numbertoHide; i++)
        {
            if (visibleWords.Count == 0)
            break;

            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }
        return $"{_reference.GetDisplayText()} - {string.Join(" ", displayWords)}";
    }

    // See if all the words are hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.isHidden())
            {
                return false;
            }
        }
        return true;
    }
}

// main
class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding."
            ),
             new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
             ),
             new Scripture(
                new Reference("John", 3, 17),
                "For God sent not his Son into the world to condemn the world; but that the world through him might be saved."
             ),
             new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."
             ),
             new Scripture(
                new Reference("3 Nephi", 27, 29),
                "Therefore, ask, and ye shall receive; knock, and it shall be opened unto you; for he that asketh, receiveth; and unto him that knocketh, it shall be opened."
             )
        };

        // Select a random scripture for the library
        Random random = new Random();
        Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // If all the words are hidden, the program finished
            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press ENTER to continue or write 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            // Hidde 3 words 
            scripture.HideRandomWords(3);
        }
    }
}