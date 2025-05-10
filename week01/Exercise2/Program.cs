using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("grade percentage");
        string answer = Console.ReadLine();
        int grade_percentage = int.Parse(answer);
        string letter = "";

        if (grade_percentage >= 90)
        {
            letter = "A";
        }
        else if (grade_percentage >= 80)
        {
            letter = "B";
        }
        else if (grade_percentage >= 70)
        {
            letter = "C";
        }
        else if (grade_percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Your grade is: {letter}");
        if (grade_percentage >= 70)
        {
            Console.WriteLine("Great!! .. You passed!");
        }
        else
        {
            Console.WriteLine("Ups, Better luck next time!");
        }
    }
}
