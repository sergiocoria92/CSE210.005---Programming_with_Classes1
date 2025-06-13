using System;
using System.Threading;
using MindfulnessApp;

class Program
{
    private const int PauseDuration = 1500;
    private const int InvalidInputPause = 2000;

    static void Main(string[] args)
    {
        InitializeProgram();
        RunMainLoop();
    }

    private static void InitializeProgram()
    {
        Console.Title = "Mindfulness Program";
        ReminderSystem.StartReminder();
    }

    private static void RunMainLoop()
    {
        while (true)
        {
            DisplayMainMenu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ExecuteActivity(new BreathingActivity());
                    break;
                case "2":
                    ExecuteActivity(new ReflectionActivity());
                    break;
                case "3":
                    ExecuteActivity(new ListingActivity());
                    break;
                case "4":
                    ShowActivityStatistics();
                    break;
                case "5":
                    SetReminderInterval();
                    break;
                case "6":
                    ExitProgram();
                    return;
                default:
                    HandleInvalidInput();
                    break;
            }
        }
    }

    private static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Mindfulness Program");
        Console.WriteLine("===================");
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflection activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. View activity statistics");
        Console.WriteLine("  5. Set reminder interval");
        Console.WriteLine("  6. Quit");
        Console.WriteLine();
        Console.Write("Select a choice from the menu: ");
    }

    private static void ExecuteActivity(Activity activity)
    {
        activity.Run();
        ActivityTracker.LogActivity(activity.GetType().Name, activity.Duration);
    }

    private static void ShowActivityStatistics()
    {
        ActivityTracker.DisplayStats();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static void SetReminderInterval()
    {
        Console.Write("\nEnter reminder interval in minutes: ");
        if (int.TryParse(Console.ReadLine(), out int minutes) && minutes > 0)
        {
            ReminderSystem.SetReminderInterval(minutes);
            Console.WriteLine($"\nReminders set for every {minutes} minutes.");
        }
        else
        {
            Console.WriteLine("\nInvalid input. Please enter a positive number.");
        }
        Thread.Sleep(InvalidInputPause);
    }

    private static void ExitProgram()
    {
        Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
        Thread.Sleep(PauseDuration);
    }

    private static void HandleInvalidInput()
    {
        Console.WriteLine("\nInvalid choice. Please try again.");
        Thread.Sleep(PauseDuration);
    }
}