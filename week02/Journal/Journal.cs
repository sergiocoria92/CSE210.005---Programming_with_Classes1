using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
        }
        else
        {
            foreach (Entry entry in _entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Date,Prompt,Response,Mood"); // CSV header

            foreach (Entry entry in _entries)
            {
                string safePrompt = entry.Prompt.Replace("\"", "\"\"");
                string safeResponse = entry.Response.Replace("\"", "\"\"");
                string safeMood = entry.Mood.Replace("\"", "\"\"");

                writer.WriteLine($"\"{entry.Date}\",\"{safePrompt}\",\"{safeResponse}\",\"{safeMood}\"");
            }
        }
        Console.WriteLine("Journal saved successfully as CSV.");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);

            for (int i = 1; i < lines.Length; i++) // skip header
            {
                string[] parts = ParseCsvLine(lines[i]);

                if (parts.Length == 4)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2], parts[3]);
                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded from CSV.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }


    private string[] ParseCsvLine(string line)
    {
        var fields = new List<string>();
        bool insideQuotes = false;
        string current = "";

        foreach (char c in line)
        {
            if (c == '"')
            {
                insideQuotes = !insideQuotes;
            }
            else if (c == ',' && !insideQuotes)
            {
                fields.Add(current.Replace("\"\"", "\""));
                current = "";
            }
            else
            {
                current += c;
            }
        }

        fields.Add(current.Replace("\"\"", "\""));
        return fields.ToArray();
    }
}
