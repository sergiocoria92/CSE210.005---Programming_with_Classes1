using System;
using System.Threading;

namespace MindfulnessApp
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public override void Run()
        {
            Start();
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            Console.WriteLine(); // Espacio antes de comenzar

            while (DateTime.Now < endTime)
            {
                // Calcular tiempo restante
                int remainingSeconds = (int)(endTime - DateTime.Now).TotalSeconds;
                
                // Asegurar que tenemos al menos 2 segundos para un mini ciclo
                if (remainingSeconds < 2) break;

                // Determinar duración de cada parte (4s inhale, 6s exhale por defecto)
                int inhaleTime = Math.Min(4, remainingSeconds / 2);
                int exhaleTime = Math.Min(6, remainingSeconds - inhaleTime);

                Console.Write("Breathe in... ");
                ShowBreathingAnimation(inhaleTime, true);
                Console.WriteLine();

                if (DateTime.Now >= endTime) break;

                Console.Write("Breathe out... ");
                ShowBreathingAnimation(exhaleTime, false);
                Console.WriteLine();
            }

            End();
        }

        private void ShowBreathingAnimation(int seconds, bool isInhaling)
        {
            int steps = seconds * 2; // Dos pasos por segundo
            for (int i = 0; i < steps; i++)
            {
                if (isInhaling)
                {
                    // Animación de expansión al inhalar
                    int size = (int)((i + 1) / (double)steps * 10);
                    Console.Write(new string('>', size));
                    Thread.Sleep(500);
                    Console.Write("\b \b".Repeat(size));
                }
                else
                {
                    // Animación de contracción al exhalar
                    int size = 10 - (int)((i + 1) / (double)steps * 10);
                    Console.Write(new string('<', size));
                    Thread.Sleep(500);
                    Console.Write("\b \b".Repeat(size));
                }
            }
        }
    }

    // Clase de extensión para repetir strings
    public static class StringExtensions
    {
        public static string Repeat(this string value, int count)
        {
            return new System.Text.StringBuilder(value.Length * count)
                .Insert(0, value, count)
                .ToString();
        }
    }
}