using System;
using System.Threading;
using MindfulnessApp;

class Program
{
    static void Main(string[] args)
    {
        // Iniciar sistema de recordatorios
        ReminderSystem.StartReminder();

        while (true)
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

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    ActivityTracker.DisplayStats();
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    continue;
                case "5":
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
                    Thread.Sleep(2000);
                    continue;
                case "6":
                    Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
                    Thread.Sleep(1500);
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    Thread.Sleep(1500);
                    continue;
            }

            // Ejecutar la actividad seleccionada
            activity.Run();
            
            // Registrar actividad en el tracker
            ActivityTracker.LogActivity(activity.GetType().Name, activity.Duration);
        }
    }
}