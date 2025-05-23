using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int count = 0;
        List<int> indices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden)
            {
                indices.Add(i);
            }
        }

        while (count < numberToHide && indices.Count > 0)
        {
            int randomIndex = _random.Next(indices.Count);
            int wordIndex = indices[randomIndex];
            _words[wordIndex].Hide();
            indices.RemoveAt(randomIndex);
            count++;
        }
    }

    public string GetDisplayText()
    {
        string text = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            text += word.GetDisplayText() + " ";
        }
        return text.Trim();
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden)
                return false;
        }
        return true;
    }
}
