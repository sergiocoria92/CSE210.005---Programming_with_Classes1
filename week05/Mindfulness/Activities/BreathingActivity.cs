using System;
using System.Threading;

namespace MindfulnessApp
{
    public class BreathingActivity : Activity
    {
        private const int DefaultInhaleTime = 4;
        private const int DefaultExhaleTime = 6;

        public BreathingActivity() : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public override void Run()
        {
            Start();
            
            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            Console.WriteLine(); // Espacio antes de comenzar

            while (DateTime.Now < endTime)
            {
                int remainingSeconds = (int)(endTime - DateTime.Now).TotalSeconds;
                
                if (remainingSeconds < 2) 
                    break;

                int inhaleTime = Math.Min(DefaultInhaleTime, remainingSeconds / 2);
                int exhaleTime = Math.Min(DefaultExhaleTime, remainingSeconds - inhaleTime);

                PerformBreathingCycle(inhaleTime, exhaleTime, endTime);
            }

            End();
        }

        private void PerformBreathingCycle(int inhaleTime, int exhaleTime, DateTime endTime)
        {
            Console.Write("Breathe in... ");
            ShowBreathingAnimation(inhaleTime, true);
            Console.WriteLine();

            if (DateTime.Now >= endTime) 
                return;

            Console.Write("Breathe out... ");
            ShowBreathingAnimation(exhaleTime, false);
            Console.WriteLine();
        }

        private void ShowBreathingAnimation(int seconds, bool isInhaling)
        {
            int steps = seconds * 2; // Dos pasos por segundo
            for (int i = 0; i < steps; i++)
            {
                if (isInhaling)
                {
                    DisplayInhaleAnimation(i, steps);
                }
                else
                {
                    DisplayExhaleAnimation(i, steps);
                }
            }
        }

        private void DisplayInhaleAnimation(int currentStep, int totalSteps)
        {
            int size = (int)((currentStep + 1) / (double)totalSteps * 10);
            Console.Write(new string('>', size));
            Thread.Sleep(500);
            ClearConsoleCharacters(size);
        }

        private void DisplayExhaleAnimation(int currentStep, int totalSteps)
        {
            int size = 10 - (int)((currentStep + 1) / (double)totalSteps * 10);
            Console.Write(new string('<', size));
            Thread.Sleep(500);
            ClearConsoleCharacters(size);
        }

        private void ClearConsoleCharacters(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write("\b \b");
            }
        }
    }
}