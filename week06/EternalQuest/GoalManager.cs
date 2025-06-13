using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;

        public void AddGoal(Goal goal) => _goals.Add(goal);

        public void RecordEvent(int goalIndex)
        {
            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                int points = _goals[goalIndex].RecordEvent();
                _score += points;
                Console.WriteLine($"You earned {points} points!");
            }
        }

        public void ShowGoals()
        {
            for (int i = 0; i < _goals.Count; i++)
                Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }

        public void ShowScore() => Console.WriteLine($"\nTotal Score: {_score}\n");

        public void Save(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (Goal goal in _goals)
                    writer.WriteLine(goal.Save());
            }
        }

        public void Load(string filename)
        {
            _goals.Clear();
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                _score = int.Parse(lines[0]);

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split('|');
                    string type = parts[0];

                    switch (type)
                    {
                        case "SimpleGoal":
                            _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])) {
                                // _isComplete is private, so consider implementing from save string if needed
                            });
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                            break;
                        case "ChecklistGoal":
                            var goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                                         int.Parse(parts[4]), int.Parse(parts[5]));
                            typeof(ChecklistGoal)
                                .GetField("_currentCount", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                .SetValue(goal, int.Parse(parts[6]));
                            _goals.Add(goal);
                            break;
                    }
                }
            }
        }

        public int GetGoalCount() => _goals.Count;
    }
}
