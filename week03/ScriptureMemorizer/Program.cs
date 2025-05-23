using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        var scriptures = new List<Scripture>()
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd, I lack nothing.")
        };

        var rnd = new Random();
        var scripture = scriptures[rnd.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("\nAll words are hidden. Good job!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            var input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;


            scripture.HideRandomWords(3);
        }
    }
}

/*
 * To exceed the basic requirements:
 * - A scripture library was implemented to choose a random scripture each time the program runs.
 * - The word-hiding function was improved to only hide words that are still visible.
 * - This aids memorization by ensuring each Enter keypress hides new and different words.
 */