using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            bool running = true;

            // CREATIVITY EXTRAS: 
            while (running)
            {
                Console.WriteLine("Eternal Quest Menu:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Show Score");
                Console.WriteLine("5. Save Goals");
                Console.WriteLine("6. Load Goals");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal(manager);
                        break;
                    case "2":
                        manager.ShowGoals();
                        break;
                    case "3":
                        manager.ShowGoals();
                        Console.Write("Which goal did you complete? ");
                        int index = int.Parse(Console.ReadLine()) - 1;
                        manager.RecordEvent(index);
                        break;
                    case "4":
                        manager.ShowScore();
                        break;
                    case "5":
                        Console.Write("Enter filename to save: ");
                        manager.Save(Console.ReadLine());
                        break;
                    case "6":
                        Console.Write("Enter filename to load: ");
                        manager.Load(Console.ReadLine());
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.\n");
                        break;
                }
            }
        }

        static void CreateGoal(GoalManager manager)
        {
            Console.WriteLine("Select goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");

            string option = Console.ReadLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine());

            switch (option)
            {
                case "1":
                    manager.AddGoal(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    manager.AddGoal(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("How many times to complete? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Bonus points on completion: ");
                    int bonus = int.Parse(Console.ReadLine());
                    manager.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }

            Console.WriteLine("Goal created!\n");
        }
    }
}
