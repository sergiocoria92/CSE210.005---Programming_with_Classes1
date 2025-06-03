public static class ReminderSystem
{
    private static Timer _reminderTimer;
    private static int _reminderInterval = 30; // minutos

    public static void StartReminder()
    {
        _reminderTimer = new Timer(ReminderCallback, null, TimeSpan.Zero, 
                                 TimeSpan.FromMinutes(_reminderInterval));
    }

    private static void ReminderCallback(object state)
    {
        Console.Beep(1000, 500);
        Console.WriteLine("\nREMINDER: Take a moment for mindfulness!");
        Console.WriteLine("Press any key to continue your current activity...");
    }

    public static void SetReminderInterval(int minutes)
    {
        _reminderInterval = minutes;
        StartReminder();
    }
}