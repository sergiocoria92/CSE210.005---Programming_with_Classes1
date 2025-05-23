using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference Reference { get; }
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public string GetDisplayText()
    {
        return $"{Reference.GetDisplayText()}\n{string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }

    public bool HideRandomWords(int count)
    {

        var notHidden = _words.Where(w => !w.IsHidden()).ToList();
        if (notHidden.Count == 0)
            return false;

        var rnd = new Random();
        int toHide = Math.Min(count, notHidden.Count);

        for (int i = 0; i < toHide; i++)
        {

            var wordToHide = notHidden[rnd.Next(notHidden.Count)];
            wordToHide.Hide();
            notHidden.Remove(wordToHide);
        }

        return true; 
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
