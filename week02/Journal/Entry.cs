public class Entry
{
    private string v1;
    private string v2;
    private string v3;

    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }
    public string Mood { get; } // <-- NEW

    public Entry(string date, string prompt, string response, string mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public Entry(string v1, string v2, string v3)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nMood: {Mood}\n";
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}|{Mood}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length == 4)
        {
            return new Entry(parts[0], parts[1], parts[2], parts[3]);
        }
        return null;
    }
}

