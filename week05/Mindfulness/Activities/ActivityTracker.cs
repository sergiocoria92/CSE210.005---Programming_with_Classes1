
public static class ActivityTracker
{
    private static Dictionary<string, int> _activityLog = new Dictionary<string, int>();

    public static void LogActivity(string activityName, int duration)
    {
        if (_activityLog.ContainsKey(activityName))
        {
            _activityLog[activityName] += duration;
        }
        else
        {
            _activityLog.Add(activityName, duration);
        }
    }

    public static void DisplayStats()
    {
        Console.Clear();
        Console.WriteLine("Activity Statistics");
        Console.WriteLine("-------------------");
        
        if (_activityLog.Count == 0)
        {
            Console.WriteLine("No activities completed yet.");
            return;
        }

        foreach (var entry in _activityLog)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} seconds");
        }

        int totalSeconds = _activityLog.Values.Sum();
        Console.WriteLine($"\nTotal mindfulness time: {totalSeconds} seconds");
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }

    internal static void LogActivity(string name, object duration)
    {
        throw new NotImplementedException();
    }
}